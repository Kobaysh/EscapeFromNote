using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    // �G�l�~�[�����X�e�[�^�X
    [SerializeField]
    protected int    hp;                // �̗�  

    [SerializeField]
    protected float  speed;             // �ړ����x

    [SerializeField]
    protected int score;             // �X�R�A

    protected int    damage;            // �U����
    protected Player player;            //�v���C���[���
    protected Rigidbody rb;           // Rigidbody

    private int DamageInvincibleTime;

    [SerializeField,Header("��e�����G����")]
    protected int DamageInvincibleTimeMax;

    private bool isDamageInvincible;

    // �G�Ƃ̔���p
    protected float interval = 3.0f;    // �v���C���[���G����
    protected float timer = 0.0f;       // �^�C�}�[�p
    protected bool isCollided = false;  // �����蔻��p

    // Start is called before the first frame update
    void Start()
    {
        //���G���
        isDamageInvincible = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(hp <= 0)
        {
            //�X�R�A����
            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().GameScore = score;

            Destroy(this.gameObject);
        }

        if (isCollided)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0.0f;
                isCollided = false;
            }
        }

        //���G���ԊǗ�
        if(isDamageInvincible)
        {
            DamageInvincibleTime++;
            if(DamageInvincibleTime >= DamageInvincibleTimeMax)
            {
                isDamageInvincible = false;
            }
        }
    }

    public virtual void Attack()
    {
    }

    public virtual void Move()
    {
    }

    // Player�ƏՓˎ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isCollided)
            {
                Debug.Log("damage");
                isCollided = true;
                timer = 0.0f;
                Player player = other.GetComponent<Player>();
                player.Damage(damage);

            }
        }
        //speed = speed * -1;
    }

    public void Damage(int amount)
    {
        if (!isDamageInvincible)
        {
            Debug.Log("��e");
            hp -= amount;
            if (hp <= 0)
            {
                hp = 0;
            }
            DamageInvincibleTime = 0;
            isDamageInvincible = true;
        }
    }
}
