using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Leave")]
public class Kanji_Leave : Kanji_Abstract
{
    public Kanji_Abstract Union_Exit;

    // Update is called once per frame
    void Update()
    {
        
    }

    //�A�N�V����
    public override void KanjiAction()
    {
        Debug.Log("�o");
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
            //�o������������
            player.GetComponent<Player>().KanjiSet(Union_Exit, false);

            return true;
        }

        return false;
    }


    //����
    public override void KanjiSeparation()
    {

    }
}
