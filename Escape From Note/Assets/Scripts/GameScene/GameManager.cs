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
    Text ScoreUI;

    [SerializeField]
    Text HPText;

    [SerializeField]
    GameObject ResultUI;

    [SerializeField]
    Text ResultUIText;

    [SerializeField]
    Text ResultScoreText;

    [SerializeField]
    private int maxEnemies = 0;

    [SerializeField]
    Text TimerText;

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
        // �v���C���[��HP�̃e�L�X�g��ύX
        HPText.text = "HP:" + player.hp.ToString();

        //�X�R�A�̃e�L�X�g�X�V
        ScoreUI.text = "SCORE�F" + GameScore;
    }

    public float GetLimitTime()
    {
        return LimitTimeMax;
    }

    //�Q�[���I��
    public void GameSet(int caseNumber)
    {
        switch (caseNumber)
        {
            case 1:
                Debug.Log("�Q�[���N���A");
                //�^�C�}�[�X�g�b�v
                TimerText.GetComponent<GameCountDown>().TimerTrigger();

                ResultUIText.text = "GAME CLEAR";
                break;

            case 2:
                Debug.Log("�Q�[���I�[�o�[");
                //�^�C�}�[�X�g�b�v
                TimerText.GetComponent<GameCountDown>().TimerTrigger();

                ResultUIText.text = "GAME OVER";
                break;

            case 3:
                Debug.Log("�^�C���I�[�o�[");
                ResultUIText.text = "TIME OVER";
                break;
        }

        ResultUI.SetActive(true);

        ResultScoreText.text = "SCORE�F" + GameScore;
    }

    public int GetMaxEnemy()
    {
        return maxEnemies;
    }
}
