using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type1 : Enemy_Base
{
    [SerializeField]
    private float[] TurnPoint=new float[2];
    private bool moveDirectionRight;

    // Start is called before the first frame update
    void Start()
    {
        // �p�����[�^�@//
        player = GameObject.Find("Player").GetComponent<Player>();   // �v���C���[�����擾
        //hp = 2;                         // �̗�       �y2�z
        speed = player.speed * 0.1f;    // �ړ����x    �y�v���C���[�̈ړ����x * 0.5�z
        damage = 2;                     // �_���[�W    �y����z
        rb = GetComponent<Rigidbody>();
        moveDirectionRight = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Move();

        if(transform.position.x<TurnPoint[0]&&!moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = true;
        }
        if(TurnPoint[1] < transform.position.x&&moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = false;
        }
    }

    public override void Attack()
    {
        Debug.Log("Enemy_Type1 Attack");
    }

    public override void Move()
    {
       // Debug.Log("Enemy_Type1 Move");

        // ���ړ��̂�
        rb.velocity = new Vector3(speed, rb.velocity.y , rb.velocity.z);
    }

}