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

    //所持している漢字
    public Kanji_Abstract kanji;

    public GameObject ItemSlot;

    //初期化
    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        kanji = null;

        //kanji = ScriptableObject.CreateInstance<Kanji_Gun>();
    }

    //更新
    void Update()
    {
        //移動処理

        //地面にいるとき
        if (characterController.isGrounded)
        {
            //歩行
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            //ジャンプ
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
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
    }

    //漢字をゲット
    public void KanjiSet(Kanji_Abstract recvKanji)
    {
        //すでに漢字を持っていた場合
        if (kanji != null)
        {
            //kanjiの関数を呼んで生成させる
            kanji.KanjiSummon();

        }

        //所持漢字をセット
        kanji = recvKanji;

        //アイテムスロットのテキスト変更
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
    }
}