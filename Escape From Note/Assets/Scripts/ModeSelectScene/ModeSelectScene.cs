using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelectScene : MonoBehaviour
{
    public Button[] ModeButtons=new Button[4];

    private int SelectState; //選択状態を格納する指数
    
    // Use this for initialization
    void Start()
    {
        SelectState = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //カーソル操作
        //上
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectState--;
            if (SelectState < 0)
            {
                SelectState = 3;
            }
        }

        //下
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SelectState++;
            if(SelectState>3)
            {
                SelectState = 0;
            }
        }

        //決定
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            switch (SelectState)
            {
                case 0:
                    SceneManager.LoadScene("TutorialStage");
                    break;
                case 3:
                    SceneManager.LoadScene("TitleScene");
                    break;
                default:
                    break;
            }
        }


        //選択状態ごとのカーソル表示
        for(int i=0;i<4;i++)
        {
            if(i==SelectState)
            {
                ModeButtons[i].GetComponent<Image>().color = Color.cyan;
            }
            else
            {
                ModeButtons[i].GetComponent<Image>().color = Color.white;
            }
           
        }
      
    }
}