using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Gold")]
public class Kanji_Gold : Kanji_Abstract
{
    public Kanji_Abstract Union_Gun;
    public Kanji_Abstract Union_Sickle;

    // Start is called before the first frame update
    public override void Kanji_Start()
    {
    }

    // Update is called once per frame
    public override void Kanji_Update()
    {

    }

    //アクション
    public override void KanjiAction()
    {

    }

    //合体可否判定
    public override bool KanjiUnionCheck()
    {
        //プレイヤーを取得
        GameObject player;
        player = GameObject.Find("Player");

        //プレイヤーのスクリプトを取得
        Player player_script = player.GetComponent<Player>();

        //スクリプト内の変数「kanji」を取得
        Kanji_Abstract getKanji = player_script.kanji;

        if (getKanji.GetType() == typeof(Kanji_Kaneru))
        {
            player.GetComponent<Player>().KanjiSet(Union_Sickle, false);

        //    return true;
        //}

        return false;
        }
    }

    //分離（派生関数）
    public override void KanjiSeparation()
    {
    }
}