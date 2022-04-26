using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type1 : Enemy_Base
{
    // Start is called before the first frame update
    void Start()
    {
        // パラメータ　//
        player = GameObject.Find("Player").GetComponent<Player>();   // プレイヤー情報を取得
        hp = 2;                         // 体力       【2】
        speed = player.speed * 0.5f;    // 移動速度    【プレイヤーの移動速度 * 0.5】
        damage = 2;                     // ダメージ    【未定】
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

    // 敵と衝突時
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