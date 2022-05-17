using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public float decreaseTime;  // Œ¸­ŠÔ
    public float interval;  // ŠÔŠu
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

        // transform‚ğæ“¾
        Transform myTransform = this.transform;

        // À•W‚ğæ“¾
        Vector3 pos = myTransform.position;
        pos.y -= 0.005f;    // yÀ•W‚Ö0.01‰ÁZ

        myTransform.position = pos;  // À•W‚ğİ’è

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


