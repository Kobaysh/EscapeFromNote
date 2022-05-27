using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KanjiObjectItem : MonoBehaviour
{
    protected GameObject player;

    //‚Á‚Ä‚¢‚éŠ¿š
    public Kanji_Abstract PossessionKanji;


    //“–‚½‚è”»’è
    virtual public void KanjiGet()
    {

    }

    //Á‹
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}
