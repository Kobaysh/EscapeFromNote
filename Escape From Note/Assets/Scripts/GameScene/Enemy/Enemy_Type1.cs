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
        // パラメータ　//
        player = GameObject.Find("Player").GetComponent<Player>();   // プレイヤー情報を取得
        //hp = 2;                         // 体力       【2】
        speed = player.speed * 0.1f;    // 移動速度    【プレイヤーの移動速度 * 0.5】
        damage = 2;                     // ダメージ    【未定】
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

        // 横移動のみ
        rb.velocity = new Vector3(speed, rb.velocity.y , rb.velocity.z);
    }

}