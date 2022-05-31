using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type1 : Enemy_Base
{
    [SerializeField,Header("最小位置")]
    private float TurnPointMin;

    [SerializeField, Header("最大位置")]
    private float TurnPointMax;

    private bool moveDirectionRight;


    // Start is called before the first frame update
    void Start()
    {
        DamageInvincibleTimeMax = 120;
        // パラメータ　//
        player = GameObject.Find("Player").GetComponent<Player>();   // プレイヤー情報を取得
        hp = 2;                         // 体力       【2】
        speed = player.speed * 0.5f;    // 移動速度    【プレイヤーの移動速度 * 0.5】
        damage = 2;                     // ダメージ    【未定】
        rb = GetComponent<Rigidbody>();
        moveDirectionRight = true;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Move();

        if (transform.position.x < TurnPointMin && !moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = true;
            sprite.flipX = true;
        }
        if (TurnPointMax < transform.position.x && moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = false;
            sprite.flipX = false;
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