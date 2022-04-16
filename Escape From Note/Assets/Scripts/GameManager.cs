using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameOverLimit = 30.0f;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOverLimit -= Time.deltaTime;

        timeText.text = gameOverLimit.ToString("f1") + "•b";

        if(gameOverLimit <= 0)
        {
            Debug.Log("time over");
            SceneManager.LoadScene(0);
        }
    }
}
