using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//漢字の抽象クラス
public abstract class Kanji_Abstract : ScriptableObject
{
    public string slotText;
    public GameObject KanjiModel;
    public int ActionAnimNum;

    public float interval;  // 生成間隔
    

    //設置
    public void KanjiSummon()
    {
        Instantiate(KanjiModel);
    }

    public void KanjiSummon(Vector3 pos)
    {
        Instantiate(KanjiModel, pos, new Quaternion());
    }

    public GameObject KanjiInstanriate(Vector3 pos)
    {
        return Instantiate(KanjiModel, pos, new Quaternion());
    }
    public GameObject KanjiInstanriate(Transform transform)
    {
        return Instantiate(KanjiModel, transform);
    }
    //純粋仮想関数-----------------------------------------------

    //アクション
    public abstract void KanjiAction();

    //合体可否判定
    public abstract bool KanjiUnionCheck();

    //分離
    public abstract void KanjiSeparation();
}