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

    //�������Ă��銿��
    public Kanji_Abstract kanji;

    public GameObject ItemSlot;

    //������
    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        kanji = null;

        //kanji = ScriptableObject.CreateInstance<Kanji_Gun>();
    }

    //�X�V
    void Update()
    {
        //�ړ�����

        //�n�ʂɂ���Ƃ�
        if (characterController.isGrounded)
        {
            //���s
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            //�W�����v
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        //�A�N�V����
        if (Input.GetMouseButtonDown(1))
        {
            if(kanji==null)
            {
                Debug.Log("���������ĂȂ����I�I�I�I�I�I�I�I");
            }
            else
            {
                kanji.KanjiAction();
            }
        }
    }

    //�������Q�b�g
    public void KanjiSet(Kanji_Abstract recvKanji)
    {
        //���łɊ����������Ă����ꍇ
        if (kanji != null)
        {
            //kanji�̊֐����Ă�Ő���������
            kanji.KanjiSummon();

        }

        //�����������Z�b�g
        kanji = recvKanji;

        //�A�C�e���X���b�g�̃e�L�X�g�ύX
        Text changeText = ItemSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
    }
}