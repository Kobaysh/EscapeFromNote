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
        //�S�[������
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�A�N�V����
    public override void KanjiAction()
    {

    }

    //���̉۔���
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //����
    public override void KanjiSeparation()
    {

    }
}
