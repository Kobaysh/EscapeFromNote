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

    private int PausmenuSelect;

    [SerializeField]
    private Button[] PauseMenuButtons=new Button[2];


    void Init()
    {
        PausmenuSelect = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                PausmenuSelect = -1;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        //ポーズ時処理
       if(pauseUI.activeSelf)
       {
            PauseMenuControll();
       }
    }

    void PauseMenuControll()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PausmenuSelect--;
            if (PausmenuSelect < 0)
            {
                PausmenuSelect = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PausmenuSelect++;
            if (PausmenuSelect > 1)
            {
                PausmenuSelect = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;

            switch (PausmenuSelect)
            {
                case 0:
                    SceneManager.LoadScene("GameScene");
                    break;

                case 1:
                    SceneManager.LoadScene("ModeSelectScene");
                    break;
            }
        }

        //選択状態ごとのカーソル表示
        for (int i = 0; i < 2; i++)
        {
            if (i == PausmenuSelect)
            {
                PauseMenuButtons[i].GetComponent<Image>().color = Color.cyan;
            }
            else
            {
                PauseMenuButtons[i].GetComponent<Image>().color = Color.white;
            }

        }
    }
}
