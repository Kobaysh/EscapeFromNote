using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelectScene : MonoBehaviour
{
    public Button[] ModeButtons=new Button[4];

    private int SelectState; //�I����Ԃ��i�[����w��

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
                    if (!TurorialTrigger.getTutorialTrigger())
                    {
                        Debug.Log("�`���[�g���A���J�n");
                        SceneManager.LoadScene("TutorialStage");

                    }

                    else
                    {
                        //�����_����1�`5�ɔ��
                        Debug.Log("�X�e�[�W�X�^�[�g");
                        int rnd = Random.Range(1, 3);
                        switch (rnd)
                        {
                            case 1:
                                SceneManager.LoadScene("Stage1");
                                break;

                            case 2:
                                SceneManager.LoadScene("Stage2");
                                break;

                            //case 3:
                            //    SceneManager.LoadScene("Stage3");
                            //    break;

                            //case 4:
                            //    SceneManager.LoadScene("Stage4");
                            //    break;

                            //case 5:
                            //    SceneManager.LoadScene("Stage5");
                            //    break;
                        }

                    }

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