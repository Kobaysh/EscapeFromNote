using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurorialTrigger : MonoBehaviour
{
    //シングルトン化
    public static bool TutorialStage = false;

    static TurorialTrigger _instance = null;

    static TurorialTrigger instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<TurorialTrigger>()); }
    }


    void Awake()
    {
        //すでに同じオブジェクトが同シーン内に存在する場合消去される
        if(this!=instance)
        {
            Destroy(this.gameObject);
            return;
        }

        //このオブジェクトはシーンを跨いでも消去されない
        DontDestroyOnLoad(this);

    }

    //シングルトン化
    void OnDestroy()
    {
        if (this == instance) _instance = null;
    }

    //チュートリアルを経過しているか
    public static bool getTutorialTrigger()
    {
        return TutorialStage;
    }
}
