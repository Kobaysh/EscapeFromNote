using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class General_Audio : MonoBehaviour {

    // static field
    static public float audioMasterVolume = 0.5f;
    static public float audioBGMVolume = 0.1f;
    static public float audioSEVolume = 1.0f;
    // public member

    // serialized field

    // private member



    public static float GetBGMVolume()
    {
        return audioMasterVolume * audioBGMVolume;
    }

    public static float GetSEVolume()
    {
        return audioMasterVolume * audioSEVolume;
    }
}