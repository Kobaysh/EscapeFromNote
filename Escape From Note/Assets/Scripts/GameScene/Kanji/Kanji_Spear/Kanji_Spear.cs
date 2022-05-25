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
    private GameObject Area2;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
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
        GameObject player = GameObject.Find("Player");
        Vector3 trans = player.transform.position;
        trans.x += 1.0f;
        Quaternion rotate = player.transform.rotation;
        //エリア1を生成
        Area1 = (GameObject)Instantiate(Collision,new Vector3(trans.x,trans.y,trans.z),rotate);
        Area1.transform.parent = player.transform;
        //エリア2を生成
        trans = player.transform.position;
        trans.x -= 1.0f;
        Area2 = (GameObject)Instantiate(Collision, new Vector3(trans.x, trans.y, trans.z), rotate);
        Area2.transform.parent = player.transform;
    }

    //合体可否判定
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //分離
    public override void KanjiSeparation()
    {
        //木

        //倉
    }
}
