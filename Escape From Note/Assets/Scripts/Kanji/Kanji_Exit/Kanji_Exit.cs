using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�p���N���X
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

    //�A�N�V�����i�h���֐��j
    public override void KanjiAction()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GameClear();
    }

    //����
    public override void KanjiUnion()
    {

    }

    //����
    public override void KanjiSeparation()
    {

    }
}
