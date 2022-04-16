using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�p���N���X
[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Fill")]
public class Kanji_Fill : Kanji_Abstract
{
    public Kanji_Abstract Union_Gun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�A�N�V�����i�h���֐��j
    public override void KanjiAction()
    {

    }

    //����
    public override void KanjiUnion()
    {
        //�v���C���[���擾
        GameObject player;
        player = GameObject.Find("Player");

        //�v���C���[�̃X�N���v�g���擾
        Player player_script = player.GetComponent<Player>();

        //�X�N���v�g���̕ϐ��ukanji�v���擾
        Kanji_Abstract getKanji = player_script.kanji;

        //�擾���Ă��������̋���������i�^���r�j
        if (getKanji.GetType() == typeof(Kanji_Gold))
        {
            Debug.Log("�[ + �� = �e");

            //�I�u�W�F�N�g����
            KanjiModel.GetComponent<KanjiObject>().DestroyKanji();

            //�e����������
            player.GetComponent<Player>().KanjiSet(Union_Gun, false);
        }
    }

    //����
    public override void KanjiSeparation()
    {

    }
}
