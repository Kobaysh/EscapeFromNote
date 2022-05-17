using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public float decreaseTime;  // ��������
    public float interval;  // �Ԋu
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

        // transform���擾
        Transform myTransform = this.transform;

        // ���W���擾
        Vector3 pos = myTransform.position;
        pos.y -= 0.005f;    // y���W��0.01���Z

        myTransform.position = pos;  // ���W��ݒ�

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


