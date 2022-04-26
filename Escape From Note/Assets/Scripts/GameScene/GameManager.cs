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

    public int GameScore { get; set; }

    [SerializeField]
    Text ScoreUI;

    [SerializeField]
    Text HPText;

    [SerializeField]
    GameObject ResultUI;

    [SerializeField]
    Text ResultScoreText;

    [SerializeField]
    private int maxEnemies = 0;

    private Player player;


    private float LimitTimeMax = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        LimitTimeMax = gameOverLimit;
        player = GameObject.Find("Player").GetComponent<Player>();

        GameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isGameClear)
        //{
        //    gameOverLimit -= Time.deltaTime;
        //}
        //timeText.text = gameOverLimit.ToString("f1") + "秒";

        //if(gameOverLimit <= 0)
        //{
        //    Debug.Log("time over");
        //    SceneManager.LoadScene(0);
        //}

        // プレイヤーのHPのテキストを変更
        HPText.text = "HP:" + player.hp.ToString();

        //スコアのテキスト更新
        ScoreUI.text = "SCORE：" + GameScore;

    }

    public float GetLimitTime()
    {
        return LimitTimeMax;
    }

    //ゲーム終了
    public void GameSet()
    {
        Debug.Log("ゲームオーバー");

        ResultUI.SetActive(true);

        ResultScoreText.text = "SCORE：" + GameScore;
    }

    public int GetMaxEnemy()
    {
        return maxEnemies;
    }
}
