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

        //カウントダウン
        if (countdown > 0)
        {
            
            countdown -= Time.deltaTime;
        }
        else
        {
            timerStop = true;
            Debug.Log("タイムオーバー");
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().GameOver();
        }

        //時間表示
        timeText.text = countdown.ToString("f1") + "秒";
    }

    public void TimerTrigger()
    {
        timerStop = true;
    }
}
