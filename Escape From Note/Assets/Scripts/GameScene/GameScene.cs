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
        // PlayerHPが０になったら　GameScene →　ModeSelectScene
        if(player.hp <= 0)
        {
            Invoke("ChangeScene", 1.5f);
        }
       
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ModeSelectScene");
    }
}