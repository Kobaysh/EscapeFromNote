using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountDown : MonoBehaviour
{
    public float countdown = 180;
    public Text timeText;
    private bool timerStop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStop) return;

        //�J�E���g�_�E��
        if (countdown > 0)
        {
            
            countdown -= Time.deltaTime;
        }
        else
        {
            timerStop = true;
            Debug.Log("�^�C���I�[�o�[");
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().GameOver();
        }

        //���ԕ\��
        timeText.text = countdown.ToString("f1") + "�b";
    }

    public void TimerTrigger()
    {
        timerStop = true;
    }
}
