using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountDown : MonoBehaviour
{
    public float countdown = 180;
    public Text timeText;
    private bool timeOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOver) return;

        //カウントダウン
        if (countdown > 0)
        {
            
            countdown -= Time.deltaTime;
        }
        else
        {
            timeOver = true;
            Debug.Log("タイムオーバー");
        }

        //時間表示
        timeText.text = countdown.ToString("f1") + "秒";
    }
}
