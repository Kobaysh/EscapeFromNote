using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour
{
    public float decreaseTime;  // Œ¸­ŽžŠÔ
    public float interval;  // ŠÔŠu
    [SerializeField]
    int damageAmount = 1;

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
            if(timer >= interval)
            {
                timer = 0.0f;
                isCollided = false;
            }
        }
    }


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
                player.hp -= damageAmount;
                if(player.hp <= 0)
                {
                    player.hp = 0;
                }

                //if (decreaseTime <= 0.0f)
                //{
                //    // 10%Œ¸­
                //    gameManager.gameOverLimit -= gameManager.GetLimitTime() * 0.1f;
                //}
                //else
                //{
                //    // Œ¸­ŽžŠÔ•ªŒ¸­
                //    gameManager.gameOverLimit -= decreaseTime;
                //}
            }
        }
    }
}
