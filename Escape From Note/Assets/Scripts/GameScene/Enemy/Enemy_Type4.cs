using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type4 : Enemy_Base
{
    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    float bullet_speed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        // �p�����[�^�@//
        player = GameObject.Find("Player").GetComponent<Player>();   // �v���C���[�����擾
        hp = 2;                         // �̗�       �y2�z
        speed = player.speed * 0.5f;    // �ړ����x    �y�v���C���[�̈ړ����x * 0.5�z
        damage = 2;                     // �_���[�W    �y����z
        rb = GetComponent<Rigidbody>();

        // �J�n�P�b�ォ��3�b���Ƃ�Attack()���Ăяo��
        InvokeRepeating("Attack", 1.0f, 3.0f);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Move();
    }

    public override void Attack()
    {
        // Debug.Log("Enemy_Type4 Attack");

        if (!GameObject.Find("Player"))
            return;

        //�v���C���[�̍��W���擾����
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // �G�l�~�[���g�̏ꏊ���擾
        Vector3 enemy_pos = this.transform.position;

        // �G�l�~�[���g����v���C���[�ւ̒P�ʃx�N�g��������o��
        Vector3 direction = player_pos - enemy_pos;
        direction.Normalize();

        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, enemy_pos + direction * 1.5f, bullet.transform.rotation);

        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * bullet_speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;

    }

    public override void Move()
    {
        // Debug.Log("Enemy_Type2 Move");

        if (!GameObject.Find("Player"))
            return;

        // �v���C���[���W���擾
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // �G�l�~�[���g�̏ꏊ���擾
        Vector3 enemy_pos = this.transform.position;

        if (enemy_pos.y > player_pos.y - 1.0f && player_pos.y + 1.0f > enemy_pos.y)
        {
            return;
        }

        // �c�ړ��̂�
        if (enemy_pos.y < player_pos.y - 1.0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
        }
        else if (enemy_pos.y > player_pos.y + 1.0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -speed, rb.velocity.z);
        }
    }

}