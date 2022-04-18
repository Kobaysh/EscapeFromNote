using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Platform")]
public class Kanji_Platform : Kanji_Abstract
{
    //���̌��̊���
    public Kanji_Abstract KanjiSub1; //��
    public Kanji_Abstract KanjiSub2; //��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�A�N�V����
    public override void KanjiAction()
    {
        Debug.Log("��");
    }

    //���̉۔���
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //����
    public override void KanjiSeparation()
    {
        //�v���C���[���擾
        GameObject player;
        player = GameObject.Find("Player");

        //�����Z�b�g
        player.GetComponent<Player>().KanjiSet(KanjiSub1, false);

        //����ݒu
        KanjiSub2.KanjiSummon();
    }
}
