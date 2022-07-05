using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Jump")]
public class Kanji_Jump : Kanji_Abstract 
{
 
    // static field

    // public member

    // serialized field

    // private member


    public override void Kanji_Start()
    {
    }

    // Update is called once per frame
    public override void Kanji_Update()
    {

    }

    // Action
    public override void KanjiAction()
	{
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.JumpEnhance();
        player.KanjiItemUsed();
    }

	// unioncheck
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    // separation
    public override void KanjiSeparation()
    {
        // ?

        // ?
    }
}