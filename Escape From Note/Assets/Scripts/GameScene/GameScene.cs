using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    // PlayerHP�𒼐ڃt�B�[���h�ɓ���ĎQ�Ƃ���
    public Player player;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�|�[�Y���������疳��
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        // PlayerHP���O�ɂȂ�����@GameScene ���@ModeSelectScene
        if (player.hp <= 0)
        {
            Invoke("ChangeScene", 1.5f);
        }
       
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ModeSelectScene");
    }
}