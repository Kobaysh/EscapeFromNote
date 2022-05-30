using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurorialTrigger : MonoBehaviour
{
    public static bool TutorialStage = false;

    void Awake()
    {
        //TutorialStage = false;
        //Debug.Log("ÉgÉäÉKÅ[ê^");
    }

    void Start()
    {
       DontDestroyOnLoad(this);   
    }

    public static bool getTutorialTrigger()
    {
        return TutorialStage;
    }
}
