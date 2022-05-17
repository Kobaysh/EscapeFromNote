using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Audio : MonoBehaviour {

    // static field

    // public member
    public enum Player_SE {
        PLAYER_SE_MOVE,
        PLAYER_SE_MOVERAISED,
        PLAYER_SE_JUMP,
        PLAYER_SE_LANDING,
        PLAYER_SE_DAMAGED,
        PLAYER_SE_MAX,
    };
    
    // serialized field

    [SerializeField, Header("SE")]
    AudioClip[] audioClips = new AudioClip[(int)Player_SE.PLAYER_SE_MAX];
    // private member

    private AudioSource audioSource = null;



    void Awake() {
        
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	

    void Update () {
	
	}
    
    public void PlaySE(Player_SE audioName, bool isLoop = false)
    {
        audioSource.clip = audioClips[(int)audioName];
        audioSource.loop = isLoop;
        if(!audioSource.isPlaying) audioSource.Play();
    }
}