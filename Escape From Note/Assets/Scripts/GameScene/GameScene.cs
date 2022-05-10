using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    // PlayerHPを直接フィールドに入れて参照する
    public Player player;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ中だったら無効
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        // PlayerHPが０になったら　GameScene →　ModeSelectScene
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