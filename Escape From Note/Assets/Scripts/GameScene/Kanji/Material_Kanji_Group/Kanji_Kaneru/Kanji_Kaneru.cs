﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Kaneru")]
public class Kanji_Kaneru : Kanji_Abstract
{

    // static field

    // public member
    public Kanji_Abstract Union_Sickle;

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
        player = GameObject.FindWithTag("Player");

        //プレイヤーのスクリプトを取得
        Player player_script = player.GetComponent<Player>();

        //スクリプト内の変数「kanji」を取得
        Kanji_Abstract getKanji = player_script.kanji;

        if (getKanji.GetType() == typeof(Kanji_Gold))
        {
            player.GetComponent<Player>().KanjiSet(Union_Sickle, false);

            return true;
        }

        return false;
    }

    // separation
    public override void KanjiSeparation()
    {

    }
}