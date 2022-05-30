using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Dash")]
public class Kanji_Dash : Kanji_Abstract {
 
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
        player.DashEnhance();
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

    }
}