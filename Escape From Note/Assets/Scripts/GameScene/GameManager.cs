using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameOverLimit = 30.0f;

    public int GameScore { get; set; }

    [SerializeField]
    private Text ScoreUI;

    [SerializeField]
    private Text HPText;

    [SerializeField]
    private GameObject ResultUI;  //リザルト画面UI

    [SerializeField]
    private Text ResultScoreText;  //リザルト画面スコアテキスト

    [SerializeField]
    private GameObject GameUI;  //ゲーム画面UI

    [SerializeField]
    private int maxEnemies = 0;

    [SerializeField]
    private Text TimerText;

    private Player player;

    [SerializeField]
    private GameObject playerPrefab;

    private float LimitTimeMax = 30.0f;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        LimitTimeMax = gameOverLimit;
        player = GameObject.Find("Player").GetComponent<Player>();

        GameScore = 0;
        GameUI.SetActive(true);

        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのHPのテキストを変更
        HPText.text = "HP:" + player.hp.ToString();

        //スコアのテキスト更新
        ScoreUI.text = "SCORE：" + GameScore;


        //ゲーム―オーバーシーンのみモードセレクトシーンに戻る
        if(isGameOver&&Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("ModeSelectScene");
        }

    }

    public float GetLimitTime()
    {
        return LimitTimeMax;
    }

    //ゲーム終了
    public void GameOver()
    {
        Debug.Log("ゲームオーバー");
        //タイマーストップ
        Time.timeScale = 0f;
        TimerText.GetComponent<GameCountDown>().TimerTrigger();

        ResultUI.SetActive(true);
        GameUI.SetActive(false);

        ResultScoreText.text = "SCORE：" + GameScore;

        isGameOver = true;
    }

    public int GetMaxEnemy()
    {
        return maxEnemies;
    }

    //プレイヤーリスポーン
    public void PlayerRespornOrder()
    {
        Debug.Log("リスポーンします");
        StartCoroutine(PlayerResporn());
    }

    private IEnumerator PlayerResporn()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("リスポーンしました");

        Instantiate(playerPrefab,new Vector3(-6.0f,0.5f,0.0f),Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //タグで検索する
    }
}