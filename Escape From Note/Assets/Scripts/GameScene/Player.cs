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

    // serialized field
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

    [SerializeField, Header("無敵時間")]
    private int InvincibleTimeMax; //無敵時間


    // private member
    private Vector3 moveDirection = Vector3.zero;  //移動方向

    private int InvincibleTime;

    private bool isBlinking;

    private Vector3 KnockbackVelocity;

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
    }

    //更新
    void Update()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("UnityChan_AnimNum_Int", AnimNum);

        //ポーズ中だったら無効
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //体力チェック
        if (hp <= 0)
        {
            //ゲームマネージャーでリスポーン手続き
            kanji = null;
            kanjiItem = null;

            Text changeKanjiText = KanjiSlot.GetComponent<Text>();
            changeKanjiText.text = "  ";

            Text changeItemText = ItemSlot.GetComponent<Text>();
            changeItemText.text = "  ";
        }
        // 着地処理
        if (!isLanding)
        {
            if (characterController.isGrounded)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_LANDING);
                isLanding = true;
            }
        }

        //地面にいるとき
        if (characterController.isGrounded)
        {
            //移動処理

            //��s
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //���t���[���x�N�g����ݒ�
            moveDirection *= speed;  //�X�s�[�h�ݒ�
            if (isDashEnhanced) moveDirection *= 1.5f;
            transform.right = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //���ݒ�
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
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                if (isJumpEnhanced) moveDirection.y *= 1.5f;
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_JUMP);
                isLanding = false;
            }

            // 漢字を捨てる
            ThrowAwayKanji();
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            transform.right = new Vector3(moveDirection.x, 0.0f, 0.0f); ;  //向きを設定
        }

        moveDirection.y -= gravity * Time.deltaTime;

        //ノックバック中以外は歩く
        if (KnockbackVelocity != Vector3.zero)
        {
            characterController.Move(KnockbackVelocity * Time.deltaTime);
        }
        else
        {
            characterController.Move(moveDirection * Time.deltaTime);

            animator.SetFloat("UnityChan_Walk_Float", Input.GetAxis("Horizontal"));
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

    public void KanjiItemUsed()
    {
        kanjiItem = null;
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = "  ";
    }

    public bool IsHPLessZero()
    {
        return (hp <= 0);
    }

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

    public void Damage(int amount)
    {

        if (isInvincible)
        {
            return;
        }

        hp -= amount;
        player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_DAMAGED);
        animator.SetTrigger("UnityChan_Damage_Trigger");

        if (hp <= 0)
        {
            hp = 0;

        }

        //無敵時間開始
        isInvincible = true;
        InvincibleTime = 0;
        KnockbackVelocity = (-transform.right * 5f);

    }

    //アタックアニメーション再生
    public void ActionAnim(int num)
    {
        if (!isOtherActionAnim)
        {

            AnimNum = num;
            animator.SetInteger("UnityChan_AnimNum_Int", AnimNum);
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

    public void KanjiEffect()
    {
        Debug.Log("効果発動");
        //アニメーションに合わせ漢字の当たり判定や効果を発動させる
        kanji.KanjiAction();
    }

    //無敵状態処理
    void InvincibleProcess()
    {
        InvincibleTime++;

        //点滅処理
        if (isBlinking)
        {
            if (InvincibleTime % 20 == 0 && InvincibleTime % 40 == 0)
            {
                this.GetComponent<Renderer>().enabled = false;
            }
            else if (InvincibleTime % 20 == 0)
            {
                this.GetComponent<Renderer>().enabled = true;
            }
        }

        //無敵時間終了
        if (InvincibleTime >= InvincibleTimeMax)
        {
            this.GetComponent<Renderer>().enabled = true;
            isBlinking = false;
            isInvincible = false;


        }
    }

    //点滅処理トリガー
    public void Blinking()
    {
        isBlinking = true;

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
}