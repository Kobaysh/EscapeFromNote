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

    //�������Ă��銿��
    public Kanji_Abstract kanji;

    public GameObject ItemSlot;
    public int hp {get;set;}

    [SerializeField]
    int startHp;

    private Player_Audio player_Audio;

    //������
    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        player_Audio = GetComponent<Player_Audio>();

        kanji = null;

        hp = startHp;

        Debug.Log("����FE�L�[ �� ����");
        Debug.Log("����F�������������Ă���ݒu���ꂽ�����̋߂���F�L�[ �� ����");
        Debug.Log("����F�������������Ă���G�L�[ �� �������̂Ă�");
    }

    //�X�V
    void Update()
    {
        //�|�[�Y���������疳��
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
            //�̗̓`�F�b�N
            if (hp<=0)
        {
            Destroy(gameObject);

            //�Q�[���}�l�[�W���[�Ń��U���g���Ăяo��
            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().GameSet(2);
        }

        //�ړ�����

        //���s
        moveDirection.x =Input.GetAxis("Horizontal");
        moveDirection.x *= speed;
        transform.right = moveDirection;

        // ���n����
        if (!isLanding)
        {
            if (characterController.isGrounded)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_LANDING);
                isLanding = true;
            }
        }

        //�n�ʂɂ���Ƃ�
        if (characterController.isGrounded)
        {
            // ���s��
            if(Mathf.Abs(Input.GetAxis("Horizontal")) >= 1.0f)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_MOVE, true);
            }

            //�W�����v
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_JUMP);
                isLanding = false;
            }

            // �������̂Ă�
            ThrowAwayKanji();
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

        //��������
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(kanji!=null)
            {
                Debug.Log("�������܂�");
                kanji.KanjiSeparation();
            }
        }
    }

    //�������Z�b�g
    public void KanjiSet(Kanji_Abstract recvKanji,bool Exchange)
    {
        //�������s����
        if (Exchange)
        {
            //���łɊ����������Ă����ꍇ
            if (kanji != null&&recvKanji!=kanji)
            {
                //kanji�̊֐����Ă�Ő���������
                kanji.KanjiSummon();
            }
        }

        //�����������Z�b�g
        kanji = recvKanji;

        //�A�C�e���X���b�g�̃e�L�X�g�ύX
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
                //kanji�̊֐����Ă�Ő���������
                kanji.KanjiSummon(transform.position);
                Debug.Log("�������̂Ă�");
                kanji = null;

                // �A�C�e���X���b�g�̃e�L�X�g�ύX
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