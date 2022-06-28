using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // static field

    // public member
    public int hp { get; set; }    //現在体力
    public float speed = 6.0f;     //移動速度
    public float jumpSpeed = 8.0f; //ジャンプ力
    public float gravity = 20.0f;  //重力

    public enum Player_Color {
        PLAYER_WHITE,
        PLAYER_YELLOW,
        PLAYER_RED,
        PLAYER_BLUE,
        PLAYER_MAX,
    }
    // serialized field
    [SerializeField] Player_Color color = Player_Color.PLAYER_WHITE;

    [SerializeField]
    private bool isLanding = true;  //着地判定

    //所持している漢字
    public Kanji_Abstract kanji;
    public Kanji_Abstract kanjiItem;

    public GameObject KanjiSlot;
    public GameObject ItemSlot;

    [SerializeField]
    int startHp;                    //初期HP

    [SerializeField]
    private int AnimNum;            //指定アニメーション番号

    [SerializeField]
    private bool isOtherActionAnim; //アニメーション重複防止

    [SerializeField]
    private bool isInvincible; //無敵状態

    [SerializeField, Header("最大無敵時間")]
    private float InvincibleTimeMax; //無敵時間


    // private member
    private Vector3 moveDirection = Vector3.zero;  //移動方向

    [SerializeField]
    private float DirectionF_or_B; //プレイヤー直立時の前後確認用

    //[SerializeField, Header("無敵時間")]
    private float InvincibleTime;

    private bool isBlinking; //点滅表示状態

    private Vector3 KnockbackVelocity;

    private bool isJumped = false;
    private bool isDoubleJump = false;
    private bool BlinkingSwitch;  //点滅状態（明・暗）
    private float BlinkingTimer;  //点滅切り替え間隔

    //component
    CharacterController characterController;  //キャラクターコントローラー
    Animator animator;                        //アニメーター
    private Player_Audio player_Audio;        //オーディオ

    private bool isJumpEnhanced;
    [SerializeField]
    private int JumpForceTimer = 0;

    private bool isDashEnhanced;
    [SerializeField]
    private int DashForceTimer = 0;

    //初期化
    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        player_Audio = GetComponent<Player_Audio>();

        kanji = null;

        hp = startHp;

        Debug.Log("操作：Eキー → 分離");
        Debug.Log("操作：漢字を所持してから設置された漢字の近くでFキー → 合体");
        Debug.Log("操作：漢字を所持してからGキー → 漢字を捨てる");

        AnimNum = 0;
        isOtherActionAnim = false;
        isInvincible = false;
        isBlinking = false;
        InvincibleTime = 0;
        KnockbackVelocity = Vector3.zero;

        KanjiSlot = GameObject.Find("GetKanjiText");
        ItemSlot = GameObject.Find("GetKanjiItemText");
    }

    //更新
    void Update()
    {

        animator = GetComponent<Animator>();

        //ポーズ中だったら無効
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        // 着地処理
        if (!isLanding)
        {
            if (characterController.isGrounded)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_LANDING);
                isLanding = true;
                isJumped = false;
                isDoubleJump = false;
            }
        }
        // ダブルジャンプ
        if (isJumpEnhanced && isJumped)
        {
            if (!isDoubleJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    isDoubleJump = true;
                }
            }
        }

        if (Input.GetAxis("Horizontal") < -0.1f || 0.1f < Input.GetAxis("Horizontal"))
        {
            DirectionF_or_B = Input.GetAxis("Horizontal");
        }

        //地面にいるとき
        if (characterController.isGrounded)
        {
            //移動処理

            //歩行
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //毎フレームベクトルを設定
            moveDirection *= speed;  //スピード設定
            if (isDashEnhanced) moveDirection *= 1.5f;

            

            transform.right = new Vector3(DirectionF_or_B, 0.0f, 0.0f);  //向きを設定

            // 歩行音
            if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 1.0f)
            {
                if (this.isDashEnhanced) player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_MOVERAISED, true);
                else player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_MOVE, false);
            }
            else
            {
                player_Audio.StopSE();
            }

            //ジャンプ
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            //    if (isJumpEnhanced) moveDirection.y *= 1.5f;
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_JUMP);
                isJumped = true;
                isLanding = false;
            }

            // 漢字を捨てる
            ThrowAwayKanji();
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            transform.right = new Vector3(DirectionF_or_B, 0.0f, 0.0f); ;  //向きを設定
        }

        moveDirection.y -= gravity * Time.deltaTime;

        //ノックバック中処理
        if (KnockbackVelocity != Vector3.zero)
        {

            characterController.Move(new Vector3(KnockbackVelocity.x,moveDirection.y,0.0f) * Time.deltaTime);

            //characterController.Move(KnockbackVelocity * Time.deltaTime);
        }

        //通常移動処理
        else
        {
            characterController.Move(moveDirection * Time.deltaTime);

            animator.SetFloat("Player_Walk_Float", Input.GetAxis("Horizontal"));
            // ジャンプ強化中
            if (isJumpEnhanced)
            {
                if (JumpForceTimer++ >= 720)
                {
                    isJumpEnhanced = false;
                    JumpForceTimer = 0;
                }
            }
            if (isDashEnhanced)
            {
                if (DashForceTimer++ >= 720)
                {
                    isDashEnhanced = false;
                    DashForceTimer = 0;
                }
            }

            //アクション
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (kanji == null)
                {
                    Debug.Log("何も持ってないぞ！！！！！！！！");
                }
                else
                {
                    //持っている漢字のActionAnimNumを取得
                    ActionAnim(kanji.ActionAnimNum);
                    animator.SetTrigger("Player_Attack_Trigger");
                }
            }
            // バフ用アイテム
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (kanjiItem == null)
                {
                    Debug.Log("何も持ってないぞ！！！！！！！！");
                }
                else
                {
                    kanjiItem.KanjiAction();
                    
                }
            }

            //分離命令
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (kanji != null)
                {
                    Debug.Log("分離します");
                    kanji.KanjiSeparation();
                }
            }

            //無敵状態処理
            if (isInvincible)
            {
                InvincibleProcess();
            }
        }
    }


    //漢字をセット
    public void KanjiSet(Kanji_Abstract recvKanji, bool Exchange)
    {
        //交換を行う時
        if (Exchange)
        {
            //すでに漢字を持っていた場合
            if (kanji != null && recvKanji != kanji)
            {
                //kanjiの関数を呼んで生成させる
                kanji.KanjiSummon(transform.position);
            }
        }

        //所持漢字をセット
        kanji = recvKanji;

        //アイテムスロットのテキスト変更
        Text changeText = KanjiSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
        //アニメーターの漢字ナンバーセット
        animator = GetComponent<Animator>();
        animator.SetInteger("Player_SetWeapon_Num_Int", recvKanji.ActionAnimNum);

    }

    //アイテム漢字をセット
    public void KanjiItemSet(Kanji_Abstract recvKanji, bool Exchange)
    {
        //交換を行う時
        if (Exchange)
        {
            //すでに漢字を持っていた場合
            if (kanji != null && recvKanji != kanji)
            {
                //kanjiの関数を呼んで生成させる
                kanji.KanjiSummon();
            }
        }

        //所持漢字をセット
        kanjiItem = recvKanji;

        //アイテムスロットのテキスト変更
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
    }

    //漢字アイテムを使う
    public void KanjiItemUsed()
    {
        kanjiItem = null;
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = "  ";
    }

    //public bool IsHPLessZero()
    //{
    //    return (hp <= 0);
    //}

    //漢字を捨てる
    private void ThrowAwayKanji()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (kanji != null)
            {
                //kanjiの関数を呼んで生成させる
                kanji.KanjiSummon(transform.position);
                Debug.Log("漢字を捨てる");
                kanji = null;

                // アイテムスロットのテキスト変更
                Text changeText = KanjiSlot.GetComponent<Text>();
                changeText.text = "  ";
            }
        }
    }

    //被ダメージ
    public void Damage(int amount)
    {

        if (isInvincible)
        {
            return;
        }

        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
        else
        {

            player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_DAMAGED);
            animator.SetTrigger("Player_Damage_Trigger");


            //無敵時間開始
            isInvincible = true;
            InvincibleTime = 0;
            KnockbackVelocity = (-transform.right * 5f);
        }
    }

    //アタックアニメーション再生
    public void ActionAnim(int num)
    {
        if (!isOtherActionAnim)
        {

            AnimNum = num;
            //animator.SetInteger("UnityChan_AnimNum_Int", AnimNum);
            AnimNum = 0;

            isOtherActionAnim = true;  //攻撃中に重ねて攻撃入力ができないようにする
        }
    }

    //アニメーションロック解除
    public void OtherActionAnimLift()
    {
        Debug.Log("アニメーションロック解除");
        isOtherActionAnim = false;
    }

    //漢字アイテムの効果発動
    public void KanjiEffect()
    {
        Debug.Log("効果発動");
        //アニメーションに合わせ漢字の当たり判定や効果を発動させる
        kanji.KanjiAction();
    }

    //無敵状態処理
    void InvincibleProcess()
    {
        InvincibleTime+=Time.deltaTime;
        BlinkingTimer+= Time.deltaTime;

        //点滅処理
        if (isBlinking)
        {
            if(BlinkingTimer>=0.2f)
            {
                if(BlinkingSwitch)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color32(155, 155, 155, 255);
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                }

                BlinkingSwitch = !BlinkingSwitch;

                BlinkingTimer = 0.0f;
            }
        }

        //無敵時間終了
        if (InvincibleTime >= InvincibleTimeMax)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            isBlinking = false;
            isInvincible = false;

            
        }
    }

    //死亡
    void Death()
    {
        //ゲームマネージャーでリスポーン手続き
        kanji = null;
        kanjiItem = null;

        Text changeKanjiText = KanjiSlot.GetComponent<Text>();
        changeKanjiText.text = "  ";

        Text changeItemText = ItemSlot.GetComponent<Text>();
        changeItemText.text = "  ";

        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().PlayerRespornOrder();
        Destroy(this.gameObject);
    }

    //点滅処理トリガー
    public void Blinking()
    {
        isBlinking = true;
        BlinkingSwitch = false;
        BlinkingTimer = 0.0f;
        KnockbackVelocity = Vector3.zero;  //ノックバック終了
    }

    public void JumpEnhance()
    {
        if (!isJumpEnhanced) isJumpEnhanced = true;
    }

    public void DashEnhance()
    {
        if (!isDashEnhanced) isDashEnhanced = true;
    }

    public void ChangeColor(int color)
    {
        if (color < 0 || color >= (int)Player_Color.PLAYER_MAX) return;
        this.color = (Player_Color)color;
        animator.SetLayerWeight((int)this.color + 1, 1.0f);

        for(int i=0;i<(int)Player_Color.PLAYER_MAX;i++)
        {
            if (i != color)
            {
                animator.SetLayerWeight(i + 1, 0.0f);
            }
        }

    }
}