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
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //アクション（派生関数）
    public override void KanjiAction()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GameClear();
    }

    //合体
    public override void KanjiUnion()
    {

    }

    //分離
    public override void KanjiSeparation()
    {

    }
}
