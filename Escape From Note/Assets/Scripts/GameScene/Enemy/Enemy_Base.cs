using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    // エネミーが持つステータス
    protected int    hp;                // 体力  
    protected float  speed;             // 移動速度
    protected int    damage;            // 攻撃力
    protected Player player;            //プレイヤー情報
    protected Rigidbody rb;           // Rigidbody


    // 敵との判定用
    protected float interval = 3.0f;    // プレイヤー無敵時間
    protected float timer = 0.0f;       // タイマー用
    protected bool isCollided = false;  // 当たり判定用

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(hp <= 0)
        {
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
    }

    public virtual void Attack()
    {
    }

    public virtual void Move()
    {
    }

    // Playerと衝突時
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
        speed = speed * -1;
    }

    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
        }
    }
}
