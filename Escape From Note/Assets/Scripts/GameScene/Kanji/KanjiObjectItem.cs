using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KanjiObjectItem : MonoBehaviour
{
    protected GameObject player;

    //持っている漢字
    public Kanji_Abstract PossessionKanji;


    //当たり判定
    virtual public void KanjiGet()
    {

    }

    //消去
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}
