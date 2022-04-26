using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�p���N���X
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_MU")]
public class Kanji_MU : Kanji_Abstract
{
    public Kanji_Abstract Union_Platform;

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

    }

    //���̉۔���
    public override bool KanjiUnionCheck()
    {
        //�v���C���[���擾
        GameObject player;
        player = GameObject.Find("Player");

        //�v���C���[�̃X�N���v�g���擾
        Player player_script = player.GetComponent<Player>();

        //�X�N���v�g���̕ϐ��ukanji�v���擾
        Kanji_Abstract getKanji = player_script.kanji;

        //�擾���Ă��������̔�r
        if (getKanji.GetType() == typeof(Kanji_Mouth))
        {
            Debug.Log("�� + �� = ��");
            //�����������
            player.GetComponent<Player>().KanjiSet(Union_Platform, false);

            return true;
        }

        return false;
    }

    //�����i�h���֐��j
    public override void KanjiSeparation()
    {
    }
}
