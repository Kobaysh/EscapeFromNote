using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationRoop : MonoBehaviour
{
    [SerializeField]
    private Animator textroop_animator;
    [SerializeField]
    private GameObject text_obj;
    [SerializeField]
    private GameObject PressEnter_obj;

    void Start_TextAnimationRoop()
    {
        textroop_animator.enabled = true;
        PressEnter_obj.SetActive(true);
        text_obj.SetActive(false);
    }

}
