using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] [Tooltip("弾の攻撃力")] private int damage = 1;

    protected float interval = 3.0f;    // プレイヤー無敵時間
    protected float timer = 0.0f;       // タイマー用
    protected bool isCollided = false;  // 当たり判定用

    // Start is called before the first frame update
    void Start()
    {
        // 出現させたボールを1.0秒後に消す
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
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

    // Playerと衝突時
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy bullet hit");

        if (other.gameObject.CompareTag("Player"))
        {
            if (!isCollided)
            {
                Debug.Log("damage");
                isCollided = true;
                timer = 0.0f;

                GameObject.Find("Player").GetComponent<Player>().Damage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
