using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    // エネミーが持つステータス
    [SerializeField]
    protected int    hp;                // 体力  

    [SerializeField]
    protected float  speed;             // 移動速度

    [SerializeField]
    protected int score;             // スコア

    protected int    damage;            // 攻撃力
    protected Player player;            //プレイヤー情報
    protected Rigidbody rb;           // Rigidbody

    private int DamageInvincibleTime;

    [SerializeField,Header("被弾時無敵時間")]
    protected int DamageInvincibleTimeMax;

    private bool isDamageInvincible;

    // 敵との判定用
    protected float interval = 3.0f;    // プレイヤー無敵時間
    protected float timer = 0.0f;       // タイマー用
    protected bool isCollided = false;  // 当たり判定用

    // Start is called before the first frame update
    void Start()
    {
        //無敵状態
        isDamageInvincible = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(hp <= 0)
        {
            //スコア処理
            GameObject gamemanager = GameObject.Find("GameManager");
            gamemanager.GetComponent<GameManager>().GameScore = score;

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

        //無敵時間管理
        if(isDamageInvincible)
        {
            DamageInvincibleTime++;
            if(DamageInvincibleTime >= DamageInvincibleTimeMax)
            {
                isDamageInvincible = false;
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
                player.Damage(damage);

            }
        }
        //speed = speed * -1;
    }

    public void Damage(int amount)
    {
        if (!isDamageInvincible)
        {
            Debug.Log("被弾");
            hp -= amount;
            if (hp <= 0)
            {
                hp = 0;
            }
            DamageInvincibleTime = 0;
            isDamageInvincible = true;
        }
    }
}
