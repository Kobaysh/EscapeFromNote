using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����̒��ۃN���X
public abstract class Kanji_Abstract : ScriptableObject
{
    public string slotText;
    public GameObject KanjiModel;

    //�ݒu
    public void KanjiSummon()
    {
        Instantiate(KanjiModel);
    }

    public void KanjiSummon(Vector3 pos)
    {
        Instantiate(KanjiModel, pos, new Quaternion());
    }

    public GameObject KanjiInstanriate(Vector3 pos)
    {
        return Instantiate(KanjiModel, pos, new Quaternion());
    }
    public GameObject KanjiInstanriate(Transform transform)
    {
        return Instantiate(KanjiModel, transform);
    }
    //�������z�֐�-----------------------------------------------

    //�A�N�V����
    public abstract void KanjiAction();

    //���̉۔���
    public abstract bool KanjiUnionCheck();

    //����
    public abstract void KanjiSeparation();
}