using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Crossbow")]
public class Kanji_Crossbow : Kanji_Bow 
{
 
    // static field

    // public member

    // serialized field

    // private member

	// Action
	// public override void KanjiAction()
	// {

	// }

	// // unioncheck
    // public override bool KanjiUnionCheck()
    // {
    //     return false;
    // }

    // separation
    public override void KanjiSeparation()
    {
        //プレイヤーを取得
        GameObject player;
        player = GameObject.Find("Player");

        //弓をセット
        player.GetComponent<Player>().KanjiSet(KanjiSub1,false);

        //奴を設置
//        KanjiSub2.KanjiSummon(player.transform.position);
    }
}