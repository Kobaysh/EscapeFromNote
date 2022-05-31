using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承クラス
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Exit")]
public class Kanji_Exit : Kanji_Abstract
{
    [SerializeField]
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //ゴール処理
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //アクション
    public override void KanjiAction()
    {

    }

    //合体可否判定
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //分離
    public override void KanjiSeparation()
    {

    }
}
