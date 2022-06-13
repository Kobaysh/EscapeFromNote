using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurorialTrigger : MonoBehaviour
{
    public static bool TutorialStage = false;

    static TurorialTrigger _instance = null;

    static TurorialTrigger instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<TurorialTrigger>()); }
    }


    void Awake()
    {
        if(this!=instance)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        //TutorialStage = false;
        //Debug.Log("トリガー真");
    }

    void OnDestroy()
    {
        if (this == instance) _instance = null;
    }

    public static bool getTutorialTrigger()
    {
        return TutorialStage;
    }
}
