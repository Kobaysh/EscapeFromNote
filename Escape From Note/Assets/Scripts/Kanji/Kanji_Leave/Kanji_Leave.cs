using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Leave")]
public class Kanji_Leave : Kanji_Abstract
{
    public Kanji_Abstract Union_Exit;

    // Update is called once per frame
    void Update()
    {
        
    }

    //アクション
    public override void KanjiAction()
    {
        Debug.Log("出");
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

        //取得していた漢字の比較
        if (getKanji.GetType() == typeof(Kanji_Mouth))
        {
            Debug.Log("ム + 口 = 台");
            //出口を所持する
            player.GetComponent<Player>().KanjiSet(Union_Exit, false);

            return true;
        }

        return false;
    }


    //分離
    public override void KanjiSeparation()
    {

    }
}
