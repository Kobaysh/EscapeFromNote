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
    private Button[] PauseMenuButtons = new Button[2];
    [SerializeField]
    private Button[] ReconfirmationButtons = new Button[2];


    void Init()
    {
        PausemenuSelect = 0;
        select = 0;
    }

    // Update is called once per frame
    void Update()
    {
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

            //選択状態ごとのカーソル表示
            for (int i = 0; i < 2; i++)
            {
                if (i == PausemenuSelect)
                {
                    PauseMenuButtons[i].GetComponent<Image>().color = Color.cyan;
                }
                else
                {
                    PauseMenuButtons[i].GetComponent<Image>().color = Color.white;
                }
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

        //選択状態ごとのカーソル表示
        for (int i = 0; i < 2; i++)
        {
            if (i == select)
            {
                ReconfirmationButtons[i].GetComponent<Image>().color = Color.cyan;
            }
            else
            {
                ReconfirmationButtons[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
}