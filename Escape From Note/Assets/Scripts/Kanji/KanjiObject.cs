using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiObject : MonoBehaviour
{
    private GameObject player;

    //持っている漢字
    public Kanji_Abstract PossessionKanji;

    // Start is called before the first frame update
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
        Destroy(gameObject);

        //UIを更新


        //アイテムスロットに格納
        //Possessionkanjiを引数にプレイヤーの関数を呼ぶ
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiSet(PossessionKanji);



    }
}