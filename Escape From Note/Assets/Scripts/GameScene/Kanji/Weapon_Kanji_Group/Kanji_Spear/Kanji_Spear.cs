using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Assets/Kanji Scriptable/Kanji_Spear")]
public class Kanji_Spear : Kanji_Abstract
{
    [SerializeField]
    private GameObject Collision;

    private bool isActive;
    private int ActiveTime;
    public int Interval;

    private GameObject Area1;

    // Start is called before the first frame update
    public override void Kanji_Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    public override void Kanji_Update()
    {
        if (!isActive)
        {
            return;
        }

        //時間経過で終了
        if(ActiveTime>=Interval)
        {

            isActive = false;
        }

        ActiveTime++;
    }

    //アクション
    public override void KanjiAction()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 pos = player.transform.position + player.transform.right * 1.5f;
        Quaternion rotate = player.transform.rotation;
        //エリア1を生成
        Area1 = (GameObject)Instantiate(Collision,new Vector3(pos.x,pos.y,pos.z),rotate);
        Area1.transform.parent = player.transform;
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
        player = GameObject.FindWithTag("Player");

        //金をセット
        player.GetComponent<Player>().KanjiSet(KanjiSub1, false);

        //充を設置
        KanjiSub2.KanjiSummon(player.transform.position);
    }
}
