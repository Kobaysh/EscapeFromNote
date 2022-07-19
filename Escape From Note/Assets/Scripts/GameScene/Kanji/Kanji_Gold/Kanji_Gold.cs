﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Gold")]
public class Kanji_Gold : Kanji_Abstract
{
    public Kanji_Abstract Union_Gun;

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

        //取得していた漢字の充だったら（型を比較）
        //if (getKanji.GetType() == typeof(Kanji_Fill))
        //{
        //    Debug.Log("金 + 充 = 銃");
        //    銃を所持する
        //    player.GetComponent<Player>().KanjiSet(Union_Gun, false);

        //    return true;
        //}

        return false;
    }

    //分離（派生関数）
    public override void KanjiSeparation()
    {
    }
}