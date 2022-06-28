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

    [SerializeField]
    private GameObject enemyPrefab;

    private float LimitTimeMax = 30.0f;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
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
            //チュートリアル終了
            if (!TurorialTrigger.getTutorialTrigger())
            {
                TurorialTrigger.TutorialStage = true;
            }

            FadeManager.FadeOut("ModeSelectScene");
          //  SceneManager.LoadScene("ModeSelectScene");
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

    //エネミー１のリスポーンオーダー
    public void Enemy_1_RespornOrder(Vector3 pos,float min, float max)
    {
        Debug.Log("エネミー１のリスポーン");
        StartCoroutine(Enemy_1_Resporn(pos, min,max));
    }

    //エネミー１リスポーン
    private IEnumerator Enemy_1_Resporn(Vector3 pos, float min, float max)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("エネミー１がリスポーンしました");

        GameObject enemy=Instantiate(enemyPrefab, new Vector3(pos.x,pos.y, pos.z), Quaternion.identity);

        Enemy_Type1 enemyCS = enemy.GetComponent<Enemy_Type1>();

        float color = Random.Range(1.0f, 4.0f);

        enemyCS.StateSet(pos,min, max,(int)color);
    }
}