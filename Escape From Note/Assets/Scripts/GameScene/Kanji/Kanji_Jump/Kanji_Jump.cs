using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Jump")]
public class Kanji_Jump : Kanji_Abstract {
 
    // static field

    // public member

    // serialized field

    // private member

    void Awake() {
        
    }

    void Start () {
	
	}
	

    void Update () {
	
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
        // —r

        // ‰H
    }
}