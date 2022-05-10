using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isLanding = true;

    //所持している漢字
    public Kanji_Abstract kanji;

    public GameObject ItemSlot;
    public int hp {get;set;}

    [SerializeField]
    int startHp;

    private Player_Audio player_Audio;

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
    }

    //更新
    void Update()
    {
        //ポーズ中だったら無効
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
            //体力チェック
            if (hp<=0)
        {
            Destroy(gameObject);

            //ゲームマネージャーでリザルトを呼び出す
            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().GameSet(2);
        }

        //移動処理

        //歩行
        moveDirection.x =Input.GetAxis("Horizontal");
        moveDirection.x *= speed;
        transform.right = moveDirection;

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
            // 歩行音
            if(Mathf.Abs(Input.GetAxis("Horizontal")) >= 1.0f)
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

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);



        //アクション
        if (Input.GetMouseButtonDown(1))
        {
            if(kanji==null)
            {
                Debug.Log("何も持ってないぞ！！！！！！！！");
            }
            else
            {
                kanji.KanjiAction();
            }
        }

        //分離命令
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(kanji!=null)
            {
                Debug.Log("分離します");
                kanji.KanjiSeparation();
            }
        }
    }

    //漢字をセット
    public void KanjiSet(Kanji_Abstract recvKanji,bool Exchange)
    {
        //交換を行う時
        if (Exchange)
        {
            //すでに漢字を持っていた場合
            if (kanji != null&&recvKanji!=kanji)
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
        hp -= amount;
        player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_DAMAGED);
        if (hp <= 0)
        {
            hp = 0;
        }
           
    }

}