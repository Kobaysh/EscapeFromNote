using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Platform")]
public class Kanji_Platform : Kanji_Abstract
{
    //合体元の漢字
    public Kanji_Abstract KanjiSub1; //ム
    public Kanji_Abstract KanjiSub2; //口

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
        Debug.Log("台");
    }

    //合体可否判定
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //分離
    public override void KanjiSeparation()
    {
        //プレイヤーを取得
        GameObject player;
        player = GameObject.Find("Player");

        //ムをセット
        player.GetComponent<Player>().KanjiSet(KanjiSub1, false);

        //口を設置
        KanjiSub2.KanjiSummon();
    }
}
