using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelectScene : MonoBehaviour
{
    public Button[] ModeButtons=new Button[4];

    private int SelectState; //�I����Ԃ��i�[����w��
    
    // Use this for initialization
    void Start()
    {
        SelectState = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\������
        //��
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectState--;
            if (SelectState < 0)
            {
                SelectState = 3;
            }
        }

        //��
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SelectState++;
            if(SelectState>3)
            {
                SelectState = 0;
            }
        }

        //����
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


        //�I����Ԃ��Ƃ̃J�[�\���\��
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