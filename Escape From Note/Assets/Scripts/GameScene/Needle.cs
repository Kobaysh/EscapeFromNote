using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public float decreaseTime;  // 減少時間
    public float interval;  // 間隔
    [SerializeField]
    int damageAmount = 2;

    private float timer = 0.0f;
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {

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

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.y -= 0.005f;    // y座標へ0.01加算

        myTransform.position = pos;  // 座標を設定

        if(myTransform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isCollided)
            {
                Debug.Log("Needle damage");
                isCollided = true;
                timer = 0.0f;
                Player player = other.GetComponent<Player>();
                player.hp -= damageAmount;
                if (player.hp <= 0)
                {
                    player.hp = 0;
                }
            }
        }
    }
}


