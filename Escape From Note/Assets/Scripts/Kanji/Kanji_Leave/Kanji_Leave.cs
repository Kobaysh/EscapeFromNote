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

    //�A�N�V����
    public override void KanjiAction()
    {
        Debug.Log("�o");
    }

    //���̉۔���
    public override bool KanjiUnionCheck()
    {
        return false;
    }


    //����
    public override void KanjiSeparation()
    {

    }
}
