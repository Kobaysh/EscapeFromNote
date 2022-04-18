using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//漢字の抽象クラス
public abstract class Kanji_Abstract : ScriptableObject
{
    public string slotText;
    public GameObject KanjiModel;

    //純粋仮想関数-----------------------------------------------

    //アクション
    public abstract void KanjiAction(); //アクション

    //設置する
    public void KanjiSummon()
    {
        Instantiate(KanjiModel);
        //呼んだ時
    }

    //合体可能か
    public abstract bool KanjiUnionCheck();

    //分離
    public abstract void KanjiSeparation();

}