using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Chase")]
public class Kanji_Chase : Kanji_Abstract
{

    // static field

    // public member
    public Kanji_Abstract Union_Hammer;

    // serialized field

    // private member

    public void Awake()
    {

    }

    public override void Kanji_Start()
    {

    }


    public override void Kanji_Update()
    {

    }

    // Action
    public override void KanjiAction()
    {

    }

    // unioncheck
    public override bool KanjiUnionCheck()
    {
        //プレイヤーを取得
        GameObject player;
        player = GameObject.Find("Player");

        //プレイヤーのスクリプトを取得
        Player player_script = player.GetComponent<Player>();

        //スクリプト内の変数「kanji」を取得
        Kanji_Abstract getKanji = player_script.kanji;

        //取得していた漢字の木だったら（型を比較）
        if (getKanji.GetType() == typeof(Kanji_Wood))
        {
            //Debug.Log("金 + 充 = 銃");
            //槍を所持する
            player.GetComponent<Player>().KanjiSet(Union_Hammer, false);

            return true;
        }

        return false;
    }

    // separation
    public override void KanjiSeparation()
    {

    }
}