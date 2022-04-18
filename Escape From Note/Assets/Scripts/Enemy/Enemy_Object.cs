using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour
{
    public float decreaseTime;  // ��������
    public float interval;  // �Ԋu

    [SerializeField]
    GameManager gameManager;

    private float timer = 0.0f;
    private bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
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
                isCollided = true;
                timer = 0.0f;

                if (decreaseTime <= 0.0f)
                {
                    // 10%����
                    gameManager.gameOverLimit -= gameManager.GetLimitTime() * 0.1f;
                }
                else
                {
                    // �������ԕ�����
                    gameManager.gameOverLimit -= decreaseTime;
                }
            }
        }
    }
}
