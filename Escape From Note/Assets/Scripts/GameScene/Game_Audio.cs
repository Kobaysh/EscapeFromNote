using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Game_Audio : MonoBehaviour {

    // static field

    // public member
    public enum BGM
    {
        BGM_1,
        BGM_2,
        BGM_3,
        BGM_4,
        BGM_ONEMINUTE,
        BGM_MAX,
    };
    // serialized field
    [SerializeField, Header("BGM")]
    private AudioClip[] audioClips = new AudioClip[(int)BGM.BGM_MAX];
    // private member
    private AudioSource audioSource = null;

    void Awake() {
        
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
        RandomPlay();   // 戦闘曲1～4でランダムBGM
    }
	

    void Update () {
	
	}

    private void RandomPlay()
    {
        int index =  Random.Range(0, (int)BGM.BGM_MAX - 1); // ラスト1分を除いてランダム
        this.PlayBGM((BGM)index);
    }

    public void PlayBGM(BGM audioName, bool isLoop = true)
    {
        audioSource.clip = audioClips[(int)audioName];
        audioSource.loop = isLoop;
        if (!audioSource.isPlaying) audioSource.Play();
    }
}