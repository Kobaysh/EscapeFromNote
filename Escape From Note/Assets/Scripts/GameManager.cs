using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameOverLimit = 30.0f;
    public Text timeText;
    public GameObject GameClearText;

    private float LimitTimeMax = 30.0f;
    private bool isGameClear = false;
    // Start is called before the first frame update
    void Start()
    {
        LimitTimeMax = gameOverLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameClear)
        {
            gameOverLimit -= Time.deltaTime;
        }
        timeText.text = gameOverLimit.ToString("f1") + "•b";

        if(gameOverLimit <= 0)
        {
            Debug.Log("time over");
            SceneManager.LoadScene(0);
        }
    }

    public float GetLimitTime()
    {
        return LimitTimeMax;
    }

    public void GameClear()
    {
        GameClearText.SetActive(true);
        isGameClear = true;
    }
}
