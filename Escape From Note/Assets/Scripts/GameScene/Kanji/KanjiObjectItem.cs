using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KanjiObjectItem : MonoBehaviour
{
    protected GameObject player;

    //�����Ă��銿��
    public Kanji_Abstract PossessionKanji;


    //�����蔻��
    virtual public void KanjiGet()
    {

    }

    //����
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}
