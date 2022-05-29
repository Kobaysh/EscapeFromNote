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

    //�������Ă��銿��
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

        AnimNum = 0;
        isOtherActionAnim = false;

        //�ʒu������
        transform.position = new Vector3(-6.0f, 0.5f, 0.0f);
    }

    //�X�V
    void Update()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("UnityChan_AnimNum_Int", AnimNum);

        //�|�[�Y���������疳��
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //�̗̓`�F�b�N
        if (hp <= 0)
        {
            //�Q�[���}�l�[�W���[�Ń��X�|�[���葱��
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
            //�ړ�����

            //���s
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //���t���[���x�N�g����ݒ�
            moveDirection *= speed;  //�X�s�[�h�ݒ�
            transform.right = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);  //������ݒ�

            // ���s��
            if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 1.0f)
            {
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_MOVE, true);
            }

            //�W�����v
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                if (isJumpEnhanced) moveDirection.y *= 1.5f;
                player_Audio.PlaySE(Player_Audio.Player_SE.PLAYER_SE_JUMP);
                isLanding = false;
            }

            // �������̂Ă�
            ThrowAwayKanji();
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
            transform.right = new Vector3(moveDirection.x, 0.0f, 0.0f); ;  //������ݒ�
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        animator.SetFloat("UnityChan_Walk_Float", Input.GetAxis("Horizontal"));

        // �W�����v������
        if (isJumpEnhanced)
        {
            JumpForceTimer++;
            if(JumpForceTimer >= 720)
            {
                isJumpEnhanced = false;
                JumpForceTimer = 0;
            }
        }

        //�A�N�V����
        if (Input.GetMouseButtonDown(1))
        {
            if (kanji == null)
            {
                //animator.SetTrigger("UnityChan_Shot_Trigger");
                Debug.Log("���������ĂȂ����I�I�I�I�I�I�I�I");
            }
            else
            {
                //�����Ă��銿����ActionAnimNum���擾
                ActionAnim(kanji.ActionAnimNum);
                
            }
        }
        // �o�t�p�A�C�e��
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(kanjiItem == null)
            {
                Debug.Log("���������ĂȂ����I�I�I�I�I�I�I�I");
            }
            else
            {
                kanjiItem.KanjiAction();
            }
        }

        //��������
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (kanji != null)
            {
                Debug.Log("�������܂�");
                kanji.KanjiSeparation();
            }
        }
    }

    //�������Z�b�g
    public void KanjiSet(Kanji_Abstract recvKanji, bool Exchange)
    {
        //�������s����
        if (Exchange)
        {
            //���łɊ����������Ă����ꍇ
            if (kanji != null && recvKanji != kanji)
            {
                //kanji�̊֐����Ă�Ő���������
                kanji.KanjiSummon(transform.position);
            }
        }

        //�����������Z�b�g
        kanji = recvKanji;

        //�A�C�e���X���b�g�̃e�L�X�g�ύX
        Text changeText = KanjiSlot.GetComponent<Text>();
        changeText.text = recvKanji.slotText;
    }

    //�A�C�e���������Z�b�g
    public void KanjiItemSet(Kanji_Abstract recvKanji, bool Exchange)
    {
        //�������s����
        if (Exchange)
        {
            //���łɊ����������Ă����ꍇ
            if (kanji != null && recvKanji != kanji)
            {
                //kanji�̊֐����Ă�Ő���������
                kanji.KanjiSummon();
            }
        }

        //�����������Z�b�g
        kanjiItem = recvKanji;

        //�A�C�e���X���b�g�̃e�L�X�g�ύX
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
                //kanji�̊֐����Ă�Ő���������
                kanji.KanjiSummon(transform.position);
                Debug.Log("�������̂Ă�");
                kanji = null;

                // �A�C�e���X���b�g�̃e�L�X�g�ύX
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

    //�A�^�b�N�A�j���[�V�����Đ�
    public void ActionAnim(int num)
    {
        if (!isOtherActionAnim)
        {

            AnimNum = num;
            animator.SetInteger("UnityChan_AnimNum_Int", AnimNum);
            AnimNum = 0;

            isOtherActionAnim = true;  //�U�����ɏd�˂čU�����͂��ł��Ȃ��悤�ɂ���
        }
    }

    //�A�j���[�V�������b�N����
    public void OtherActionAnimLift()
    {
        Debug.Log("�A�j���[�V�������b�N����");
        isOtherActionAnim = false;
    }

    public void KanjiEffect()
    {
        Debug.Log("���ʔ���");
        //�A�j���[�V�����ɍ��킹�����̓����蔻�����ʂ𔭓�������
        kanji.KanjiAction();
    }

    public void JumpEnhance()
    {
        if(!isJumpEnhanced) isJumpEnhanced = true;
    }

}