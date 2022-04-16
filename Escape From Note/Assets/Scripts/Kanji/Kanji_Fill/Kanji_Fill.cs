using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Fill")]
public class Kanji_Fill : Kanji_Abstract
{
    public Kanji_Abstract Union_Gun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //アクション（派生関数）
    public override void KanjiAction()
    {

    }

    //合体
    public override void KanjiUnion()
    {
        //プレイヤーを取得
        GameObject player;
        player = GameObject.Find("Player");

        //プレイヤーのスクリプトを取得
        Player player_script = player.GetComponent<Player>();

        //スクリプト内の変数「kanji」を取得
        Kanji_Abstract getKanji = player_script.kanji;

        //取得していた漢字の金だったら（型を比較）
        if (getKanji.GetType() == typeof(Kanji_Gold))
        {
            Debug.Log("充 + 金 = 銃");

            //オブジェクト消去
            KanjiModel.GetComponent<KanjiObject>().DestroyKanji();

            //銃を所持する
            player.GetComponent<Player>().KanjiSet(Union_Gun, false);
        }
    }

    //分離
    public override void KanjiSeparation()
    {

    }
}
