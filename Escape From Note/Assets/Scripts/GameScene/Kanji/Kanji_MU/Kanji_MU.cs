using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_MU")]
public class Kanji_MU : Kanji_Abstract
{
    public Kanji_Abstract Union_Platform;

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
            //台を所持する
            player.GetComponent<Player>().KanjiSet(Union_Platform, false);

            return true;
        }

        return false;
    }

    //分離（派生関数）
    public override void KanjiSeparation()
    {
    }
}
