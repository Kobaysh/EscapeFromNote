using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName="Assets/Kanji Scriptable/Kanji_Gun")]
public class Kanji_Gun : Kanji_Abstract
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アクション
    public override void KanjiAction()
    {
        Debug.Log("銃");
    }
}