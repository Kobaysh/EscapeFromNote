using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiItem : MonoBehaviour
{
    private GameObject player;

    //持っている漢字
    public Kanji_Abstract PossessionKanji;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //当たり判定
    public void KanjiGet()
    {
        DestroyKanji();

        //アイテムスロットに格納
        //Possessionkanjiを引数にプレイヤーの関数を呼ぶ
        player = GameObject.Find("Player");
     //   player.GetComponent<Player>().KanjiSet(PossessionKanji, true);

        //スコア加算(試験的)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

    //消去
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}
