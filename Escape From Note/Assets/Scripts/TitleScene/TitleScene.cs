using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private Animator title_animator;
    [SerializeField]
    private Animator text_animator;
    [SerializeField]
    private Animator title_down_animator;
    [SerializeField]
    private Animator text_down_animator;
    [SerializeField]
    private Animator textroop_animator;
    [SerializeField]
    private GameObject textroop_obj;
    [SerializeField]
    private GameObject logoBG;
    [SerializeField]
    private Image logoSprite;
    [SerializeField]
    private float logoTime;
    [SerializeField]
    private GameObject PressEnter_obj;

    private bool isPlayingVideo;
    private float timer = 0.0f;
    private bool isActive = false;
    private float logoAlpha;
    private short flag = 0;
    // Use this for initialization
    void Start()
    {
        isPlayingVideo = false;
        timer = 0.0f;
        logoAlpha = 0.0f;
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayingVideo)
        {
            timer += Time.deltaTime;
            if (timer < logoTime * 0.25)
            {
                logoSprite.color = new Color(1.0f, 1.0f, 1.0f, logoAlpha);
                logoAlpha += 0.01f;
            }
            else if (timer >= logoTime * 0.75 && timer < logoTime)
            {
                logoSprite.color = new Color(1.0f, 1.0f, 1.0f, logoAlpha);
                logoAlpha -= 0.01f;
            }
            else if (timer >= logoTime)
            {
                isPlayingVideo = true;
                logoBG.SetActive(false);
                if(flag == 0)
                flag = 1;
                if(flag == 1)
                {
                    title_animator.enabled = true;
                    text_animator.enabled = true;
                    flag = 2;
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            textroop_obj.SetActive(false);
            PressEnter_obj.SetActive(false);
            title_down_animator.enabled = true;
            text_down_animator.enabled = true;

           //SceneManager.LoadScene("ModeSelectScene");
        }
    }
   
    
}

