using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private bool isLanding = true;

    //所持している漢字
    public Kanji_Abstract kanji;
    public Kanji_Abstract kanjiItem;

    public GameObject KanjiSlot;
    public GameObject ItemSlot;
    public int hp { get; set; }

    [SerializeField]
    int startHp;

    private Player_Audio player_Audio;

    [SerializeField]
    private int AnimNum;
    [SerializeField]
    private bool isOtherActionAnim;

    private bool isJumpEnhanced;
    [SerializeField]
    private int JumpForceTimer = 0;

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

        //位置初期化
        transform.position = new Vector3(-6.0f, 0.5f, 0.0f);
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

            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().PlayerRespornOrder();
            int score = gamemanager.GetComponent<GameManager>().GameScore;
            score -= 1000;
            if(score<0)
            {
                score = 0;
            }

            gamemanager.GetComponent<GameManager>().GameScore = score;

            Destroy(gameObject);
            
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
        characterController.Move(moveDirection * Time.deltaTime);
        animator.SetFloat("UnityChan_Walk_Float", Input.GetAxis("Horizontal"));

        // ジャンプ強化中
        if (isJumpEnhanced)
        {
            JumpForceTimer++;
            if(JumpForceTimer >= 720)
            {
                isJumpEnhanced = false;
                JumpForceTimer = 0;
            }
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
        // バフ用アイテム
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(kanjiItem == null)
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
        hp -= amount;
        player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_DAMAGED);
        if (hp <= 0)
        {
            hp = 0;
        }

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

    public void JumpEnhance()
    {
        if(!isJumpEnhanced) isJumpEnhanced = true;
    }

}