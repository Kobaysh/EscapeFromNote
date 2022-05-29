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
    private GameObject ResultUI;  //���U���g���UI

    [SerializeField]
    private Text ResultScoreText;  //���U���g��ʃX�R�A�e�L�X�g

    [SerializeField]
    private GameObject GameUI;  //�Q�[�����UI

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
        // �v���C���[��HP�̃e�L�X�g��ύX
        HPText.text = "HP:" + player.hp.ToString();

        //�X�R�A�̃e�L�X�g�X�V
        ScoreUI.text = "SCORE�F" + GameScore;


        //�Q�[���\�I�[�o�[�V�[���̂݃��[�h�Z���N�g�V�[���ɖ߂�
        if(isGameOver&&Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("ModeSelectScene");
        }

    }

    public float GetLimitTime()
    {
        return LimitTimeMax;
    }

    //�Q�[���I��
    public void GameOver()
    {
        Debug.Log("�Q�[���I�[�o�[");
        //�^�C�}�[�X�g�b�v
        Time.timeScale = 0f;
        TimerText.GetComponent<GameCountDown>().TimerTrigger();

        ResultUI.SetActive(true);
        GameUI.SetActive(false);

        ResultScoreText.text = "SCORE�F" + GameScore;

        isGameOver = true;
    }

    public int GetMaxEnemy()
    {
        return maxEnemies;
    }

    //�v���C���[���X�|�[��
    public void PlayerRespornOrder()
    {
        Debug.Log("���X�|�[�����܂�");
        StartCoroutine(PlayerResporn());
    }

    private IEnumerator PlayerResporn()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("���X�|�[�����܂���");

        Instantiate(playerPrefab,new Vector3(-6.0f,0.5f,0.0f),Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //�^�O�Ō�������
    }
}