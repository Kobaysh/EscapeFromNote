using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiObject : KanjiObjectItem
{
 
    //当たり判定
    public override void KanjiGet()
    {
        DestroyKanji();

        //アイテムスロットに格納
        //Possessionkanjiを引数にプレイヤーの関数を呼ぶ
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiSet(PossessionKanji,true);

        //スコア加算(試験的)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

    //合体命令
    public void KanjiUnionOrder()
    {
        Debug.Log("合体します。");

        //PossessionKanji.KanjiUnion();

        //PossesionKanjiからではなく、ここから消去命令を出さなければならない
        //所持漢字のbool関数を呼び、真が出れば消去する
        if(PossessionKanji.KanjiUnionCheck())
        {
            DestroyKanji();
        }

    }
}