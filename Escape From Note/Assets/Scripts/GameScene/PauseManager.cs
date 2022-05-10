using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //�@�|�[�Y�������ɕ\������UI
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
            //�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
            pauseUI.SetActive(!pauseUI.activeSelf);

            //�@�|�[�YUI���\������Ă鎞�͒�~
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                PausmenuSelect = -1;
                //�@�|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        //�|�[�Y������
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

        //�I����Ԃ��Ƃ̃J�[�\���\��
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
