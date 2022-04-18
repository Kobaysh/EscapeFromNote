using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����̒��ۃN���X
public abstract class Kanji_Abstract : ScriptableObject
{
    public string slotText;
    public GameObject KanjiModel;

    //�������z�֐�-----------------------------------------------

    //�A�N�V����
    public abstract void KanjiAction(); //�A�N�V����

    //�ݒu����
    public void KanjiSummon()
    {
        Instantiate(KanjiModel);
        //�Ă񂾎�
    }

    //���̉\��
    public abstract bool KanjiUnionCheck();

    //����
    public abstract void KanjiSeparation();

}