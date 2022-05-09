using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type3 : Enemy_Base
{
    // Start is called before the first frame update
    void Start()
    {
        // �p�����[�^�@//
        player = GameObject.Find("Player").GetComponent<Player>();   // �v���C���[�����擾
        hp = 3;                         // �̗�       �y3�z
        speed = player.speed * 0.75f;   // �ړ����x    �y�v���C���[�̈ړ����x * 0.75�z
        damage = 2;                     // �_���[�W    �y����z
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Move();
    }

    public override void Attack()
    {
        Debug.Log("Enemy_Type1 Attack");
    }

    public override void Move()
    {
        // Debug.Log("Enemy_Type1 Move");

        if (!GameObject.Find("Player"))
            return;

        // �v���C���[���W���擾
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // �G�l�~�[���g�̏ꏊ���擾
        Vector3 enemy_pos = this.transform.position;

        if (enemy_pos.x > player_pos.x - 1.0f && player_pos.x + 1.0f > enemy_pos.x)
        {
            return;
        }

        // ���ړ��̂�
        if (enemy_pos.x < player_pos.x - 1.0f)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        else if(enemy_pos.x > player_pos.x + 1.0f)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
       
    }

}