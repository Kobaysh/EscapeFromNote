using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Tooltip("弾の攻撃力")] private int damage = 1;

    private string enemy_name;

    // Start is called before the first frame update
    void Start()
    {
        // 出現させたボールを1.0秒後に消す
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Enemyと衝突時
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy bullet hit");

        if (other.gameObject.CompareTag("enemy"))
        {
            enemy_name = other.gameObject.name;

            GameObject.Find(enemy_name).GetComponent<Enemy_Base>().Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
