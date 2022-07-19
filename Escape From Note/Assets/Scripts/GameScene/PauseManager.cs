using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    //　再確認表示するUI
    [SerializeField]
    private GameObject reconfirmationUI;
    [SerializeField]
    private int PausemenuSelect;
    [SerializeField]
    private int select; // select   -1(初期値) 0(YES) 1(NO)

    [SerializeField]
    private GameObject circle;

    [SerializeField]
    private Button[] PauseMenuButtons = new Button[2];
    [SerializeField]
    private Button[] ReconfirmationButtons = new Button[2];

    private Vector3 LeftSelect = new Vector3(-440.0f,-337.0f,0.0f);
    private Vector3 RightSelect = new Vector3(440.0f, -337.0f, 0.0f);

    private RectTransform CircleRect;

    void Init()
    {
        PausemenuSelect = 0;
        select = 0;
    }
    private void Start()
    {
        Debug.Log("Start");
        pauseUI = GameObject.Find("PauseUIPanel");
        PauseMenuButtons[0] = GameObject.Find("RestartButtonUI").GetComponent<Button>();
        PauseMenuButtons[1] = GameObject.Find("ToMenuButtonUI").GetComponent<Button>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseUI.activeSelf || reconfirmationUI.activeSelf)
        {
            circle.SetActive(true);
        }
        else
        {
            circle.SetActive(false);
        }

        if (Input.GetKeyDown("q") && !reconfirmationUI.activeSelf)
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                PausemenuSelect = 0;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else if(reconfirmationUI.activeSelf)
            {
                Time.timeScale = 0f;
                select = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        //ポーズ時処理
        if (pauseUI.activeSelf)
        {
            PauseMenuControll();
        }

        //再確認処理
        if(reconfirmationUI.activeSelf)
        {
            ReconfirmationControll();
        }
    }

    void PauseMenuControll()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PausemenuSelect--;
            if (PausemenuSelect < 0)
            {
                PausemenuSelect = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PausemenuSelect++;
            if (PausemenuSelect > 1)
            {
                PausemenuSelect = 0;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            //再確認用UIアクティブ
            reconfirmationUI.SetActive(true);
            //ポーズUI非アクティブ
            pauseUI.SetActive(false);
        }

        if (0 == PausemenuSelect)
        {
            CircleRect = circle.GetComponent<RectTransform>();
            CircleRect.localPosition = LeftSelect;
        }
        else
        {
            CircleRect = circle.GetComponent<RectTransform>();
            CircleRect.localPosition = RightSelect;
        }

    }//!PauseMenuControll

    //---------------------------------------------------------------
    //再確認用のUI表示
    //---------------------------------------------------------------
    void ReconfirmationControll()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
                select--;
            if (select < 0)
            {
                    select = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
                select++;
            if (select > 1)
            {
                    select = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            
            //YESだったら
            if (select == 0)
            {
                    //ポーズメニューで選択したものを実行する
                    switch (PausemenuSelect)
                    {
                        case 0:
                        //リスタート
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        break;

                        case 1:
                        //チュートリアル終了
                        if (!TurorialTrigger.getTutorialTrigger())
                        {
                            TurorialTrigger.TutorialStage = true;
                        }
                        SceneManager.LoadScene("ModeSelectScene");
                        break;
                    }
            }
            //NOだったら
            else if (select == 1)
            {
                //　ポーズUIの非アクティブ
                reconfirmationUI.SetActive(false);
            }
        }


        if (0 == select)
        {
            CircleRect = circle.GetComponent<RectTransform>();
            CircleRect.localPosition = LeftSelect;
        }
        else
        {
            CircleRect = circle.GetComponent<RectTransform>();
            CircleRect.localPosition = RightSelect;
        }
    }
}