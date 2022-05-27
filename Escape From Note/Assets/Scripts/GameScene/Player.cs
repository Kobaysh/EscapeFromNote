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
    public Kanji_Abstract kanji;   //所持漢字
    public GameObject ItemSlot;    //漢字スロット

    // serialized field
    [SerializeField]
    private bool isLanding = true;  //着地判定

    [SerializeField]
    int startHp;                    //初期HP

    [SerializeField]
    private int AnimNum;            //指定アニメーション番号

    [SerializeField]
    private bool isOtherActionAnim; //アニメーション重複防止

    [SerializeField]
    private bool isInvincible; //無敵状態

    [SerializeField,Header("無敵時間")]
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
            Destroy(gameObject);

            //ゲームマネージャーでリザルトを呼び出す
            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().GameSet(2);
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

            //歩行
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //毎フレームベクトルを設定
            moveDirection *= speed;  //スピード設定
            transform.right = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //向きを設定

            // 歩行音
            if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 1.0f)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_MOVE, true);
            }

            //ジャンプ
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
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
        }

        //アクション
        if (Input.GetMouseButtonDown(1))
        {
            if (kanji == null)
            {
                //animator.SetTrigger("UnityChan_Shot_Trigger");
                Debug.Log("何も持ってないぞ！！！！！！！！");
            }
            else
            {
                //持っている漢字のActionAnimNumを取得
                ActionAnim(kanji.ActionAnimNum);
                
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
        if(isInvincible)
        {
            InbincibleProcess();
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
                kanji.KanjiSummon();
            }
        }

        //所持漢字をセット
        kanji = recvKanji;

        //アイテムスロットのテキスト変更
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
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
                Text changeText = ItemSlot.GetComponent<Text>();
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
    void InbincibleProcess()
    {
        InvincibleTime++;

        //点滅処理
        if(isBlinking)
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

}