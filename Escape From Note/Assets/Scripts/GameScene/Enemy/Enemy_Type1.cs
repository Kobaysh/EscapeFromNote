using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type1 : Enemy_Base
{
    // Start is called before the first frame update
    void Start()
    {
        // �p�����[�^�@//
        player = GameObject.Find("Player").GetComponent<Player>();   // �v���C���[�����擾
        hp = 2;                         // �̗�       �y2�z
        speed = player.speed * 0.5f;    // �ړ����x    �y�v���C���[�̈ړ����x * 0.5�z
        damage = 2;                     // �_���[�W    �y����z
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        Debug.Log("Enemy_Type1 Attack");
    }

    public override void Move()
    {
        Debug.Log("Enemy_Type1 Move");
    }

    // �G�ƏՓˎ�
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
                player.hp -= damage;
                if (player.hp <= 0)
                {
                    player.hp = 0;
                }
            }
        }
    }
}