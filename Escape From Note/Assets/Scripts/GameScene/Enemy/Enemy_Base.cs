using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    public enum EnemyColor
    {
        ENEMY_WHITE,
        ENEMY_YELLOW,
        ENEMY_RED,
        ENEMY_BLUE,
        ENEMY_MAX,
    }

    // エネミーが持つステータス
    [SerializeField]
    protected int    hp;                // 体力  

    [SerializeField]
    protected float  speed;             // 移動速度

    [SerializeField]
    protected int score;             // スコア

    [SerializeField, Header("初期位置")]
    protected Vector3 StartPos;

    protected int    damage;            // 攻撃力
    protected Player player;            //プレイヤー情報
    protected Rigidbody rb;           // Rigidbody

    protected SpriteRenderer sprite;

    private int DamageInvincibleTime;

    [SerializeField,Header("被弾時無敵時間")]
    protected int DamageInvincibleTimeMax;

    [SerializeField, Header("色")]
    protected EnemyColor color;

    private bool isDamageInvincible;

    // 敵との判定用
    protected float interval = 3.0f;    // プレイヤー無敵時間
    protected float timer = 0.0f;       // タイマー用
    protected bool isCollided = false;  // 当たり判定用

    protected Enemy_Audio enemy_Audio;  // 音
    protected bool isDeleting = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //無敵状態
        isDamageInvincible = false;
        if (!enemy_Audio) enemy_Audio = GetComponent<Enemy_Audio>();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isDeleting)
        {
            // 再生が終わったら消去
            if (!enemy_Audio.isPlaying())
            {
                //スコア処理
                GameObject gamemanager = GameObject.Find("GameManager");
                gamemanager.GetComponent<GameManager>().GameScore = score;
                DeathProcess();
                


                Destroy(this.gameObject);
            }
            return;
        }
        if (hp <= 0)
        {
            enemy_Audio.PlaySE(Enemy_Audio.Enemy_SE.ENEMY_SE_DESPAWN);
            isDeleting = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
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

    //各エネミー固有の死亡処理
    public virtual void DeathProcess()
    {
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
        if (isDeleting) return;
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
    }

    public void Damage(int amount)
    {
        if (isDeleting) return;
        if (!isDamageInvincible)
        {
            Debug.Log("被弾");
            hp -= amount;
            // 被弾SE
            enemy_Audio.PlaySE(Enemy_Audio.Enemy_SE.ENEMY_SE_DAMAGE);
            if (hp <= 0)
            {
                hp = 0;
            }
            DamageInvincibleTime = 0;
            isDamageInvincible = true;
        }
    }
}
