using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type3 : Enemy_Base
{
    // Start is called before the first frame update
    void Start()
    {
        // パラメータ　//
        player = GameObject.Find("Player").GetComponent<Player>();   // プレイヤー情報を取得
        hp = 3;                         // 体力       【3】
        speed = player.speed * 0.75f;   // 移動速度    【プレイヤーの移動速度 * 0.75】
        damage = 2;                     // ダメージ    【未定】
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

        // プレイヤー座標を取得
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // エネミー自身の場所を取得
        Vector3 enemy_pos = this.transform.position;

        if (enemy_pos.x > player_pos.x - 1.0f && player_pos.x + 1.0f > enemy_pos.x)
        {
            return;
        }

        // 横移動のみ
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