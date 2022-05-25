using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Enemy_Audio : MonoBehaviour {

    // static field

    // public member
    public enum Enemy_SE
    {
        ENEMY_SE_DAMAGE,
        ENEMY_SE_DAMAGE_CRI,
        ENEMY_SE_SHOT1,
        ENEMY_SE_SHOT2,
        ENEMY_SE_SPAWN,
        ENEMY_SE_DESPAWN,
        ENEMY_SE_SCORE,
        ENEMY_SE_MAX,
    }

    // serialized field
    [SerializeField, HideInInspector]
    AudioClip damage;
    [SerializeField, HideInInspector]
    AudioClip damage_cri;
    [SerializeField, HideInInspector]
    AudioClip shot1;
    [SerializeField, HideInInspector]
    AudioClip shot2;
    [SerializeField, HideInInspector]
    AudioClip spawn;
    [SerializeField, HideInInspector]
    AudioClip despawn;
    [SerializeField, HideInInspector]
    AudioClip score;
    // private member
    private AudioSource audioSource;
    private AudioClip[] audioClips = new AudioClip[(int)Enemy_SE.ENEMY_SE_MAX];

    void Start () {
        if (TryGetComponent<AudioSource>(out audioSource))
        {
         //   audioSource = GetComponent<AudioSource>();
        }
        else
        {
            audioSource =  this.gameObject.AddComponent<AudioSource>();
        }

        audioClips[(int)Enemy_SE.ENEMY_SE_DAMAGE] = damage;
        audioClips[(int)Enemy_SE.ENEMY_SE_DAMAGE_CRI] = damage_cri;
        audioClips[(int)Enemy_SE.ENEMY_SE_SHOT1] = shot1;
        audioClips[(int)Enemy_SE.ENEMY_SE_SHOT2] = shot2;
        audioClips[(int)Enemy_SE.ENEMY_SE_SPAWN] = spawn;
        audioClips[(int)Enemy_SE.ENEMY_SE_DESPAWN] = despawn;
        audioClips[(int)Enemy_SE.ENEMY_SE_SCORE] = score;
	}
	

    public void PlaySE(Enemy_SE audioName, bool isLoop = false)
    {
        audioSource.clip = audioClips[(int)audioName];
        audioSource.loop = isLoop;
        audioSource.volume = General_Audio.GetSEVolume();
        if (!audioSource.isPlaying) audioSource.Play();
    }
}