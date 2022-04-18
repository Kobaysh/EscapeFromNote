using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Leave")]
public class Kanji_Leave : Kanji_Abstract
{
    // Update is called once per frame
    void Update()
    {
        
    }

    //アクション
    public override void KanjiAction()
    {
        Debug.Log("出");
    }

    //合体可否判定
    public override bool KanjiUnionCheck()
    {
        return false;
    }


    //分離
    public override void KanjiSeparation()
    {

    }
}
