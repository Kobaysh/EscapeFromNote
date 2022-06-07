using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type4 : Enemy_Base
{
    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    float bullet_speed = 30.0f;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        // パラメータ　//
        player = GameObject.Find("Player").GetComponent<Player>();   // プレイヤー情報を取得
        hp = 2;                         // 体力       【2】
        speed = player.speed * 0.5f;    // 移動速度    【プレイヤーの移動速度 * 0.5】
        damage = 2;                     // ダメージ    【未定】
        rb = GetComponent<Rigidbody>();

        // 開始１秒後から3秒ごとにAttack()を呼び出す
        InvokeRepeating("Attack", 1.0f, 3.0f);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isDeleting) return;
        Move();
    }

    public override void Attack()
    {
        // Debug.Log("Enemy_Type4 Attack");

        if (!GameObject.Find("Player"))
            return;

        //プレイヤーの座標を取得する
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // エネミー自身の場所を取得
        Vector3 enemy_pos = this.transform.position;

        // エネミー自身からプレイヤーへの単位ベクトルを割り出す
        Vector3 direction = player_pos - enemy_pos;
        direction.Normalize();

        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, enemy_pos + direction * 1.5f, bullet.transform.rotation);

        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * bullet_speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;

    }

    public override void Move()
    {
        // Debug.Log("Enemy_Type2 Move");

        if (!GameObject.Find("Player"))
            return;

        // プレイヤー座標を取得
        Vector3 player_pos = GameObject.Find("Player").transform.position;

        // エネミー自身の場所を取得
        Vector3 enemy_pos = this.transform.position;

        if (enemy_pos.y > player_pos.y - 1.0f && player_pos.y + 1.0f > enemy_pos.y)
        {
            return;
        }

        // 縦移動のみ
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