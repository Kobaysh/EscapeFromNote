using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiItem : KanjiObjectItem
{
    //当たり判定
    public override void  KanjiGet()
    {
        DestroyKanji();

        //アイテムスロットに格納
        //Possessionkanjiを引数にプレイヤーの関数を呼ぶ
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiItemSet(PossessionKanji, true);

        //スコア加算(試験的)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

}
