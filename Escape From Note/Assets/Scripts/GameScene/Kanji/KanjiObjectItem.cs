using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KanjiObjectItem : MonoBehaviour
{
    protected GameObject player;

    //??????????????
    public Kanji_Abstract PossessionKanji;


    //??????????
    virtual public void KanjiGet()
    {

    }

    //????
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }

    // private void OnTriggerStay(Collider other) 
    // {
    //     if(other.gameObject.CompareTag("kanji"))
    //     {
    //         Vector3 pos = this.gameObject.transform.position;
    //         this.gameObject.transform.position = new Vector3((float)(pos.x + 0.001f), pos.y, pos.z);
    //         Debug.Log("ずらし");
            
    //     }
    // }
}
