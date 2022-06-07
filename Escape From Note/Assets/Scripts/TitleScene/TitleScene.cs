using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject videoCanvas;
    [SerializeField]
    private VideoPlayer video;
    [SerializeField]
    private GameObject logoBG;
    [SerializeField]
    private Image logoSprite;
    [SerializeField]
    private float logoTime;

    private bool isPlayingVideo;
    private float timer = 0.0f;
    private bool isActive = false;
    private float logoAlpha;
    // Use this for initialization
    void Start()
    {
        isPlayingVideo = false;
        timer = 0.0f;
        logoAlpha = 0.0f;
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
                video.loopPointReached += LoopPointReached;
                video.Play();
            }
        }
        if (isPlayingVideo)
        {
            isActive = false;
        }

        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
             //   SceneManager.LoadScene("ModeSelectScene");
            }
        }
    }

    // ビデオ終了時の処理
    private void LoopPointReached(VideoPlayer vp)
    {
        isActive = true;
        videoCanvas.SetActive(false);
        FadeManager.FadeOut("ModeSelectScene");
     //   SceneManager.LoadScene("ModeSelectScene");
    }

}