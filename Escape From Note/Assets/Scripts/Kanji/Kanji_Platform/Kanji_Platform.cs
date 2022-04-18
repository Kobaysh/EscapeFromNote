using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Platform")]
public class Kanji_Platform : Kanji_Abstract
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //ÉAÉNÉVÉáÉì
    public override void KanjiAction()
    {
        Debug.Log("ë‰");
    }

    //çáëÃ
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //ï™ó£
    public override void KanjiSeparation()
    {

    }
}
