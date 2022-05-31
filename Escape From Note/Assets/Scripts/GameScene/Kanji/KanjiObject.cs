using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiObject : KanjiObjectItem
{
 
    //�����蔻��
    public override void KanjiGet()
    {
        DestroyKanji();

        //�A�C�e���X���b�g�Ɋi�[
        //Possessionkanji�������Ƀv���C���[�̊֐����Ă�
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiSet(PossessionKanji,true);

        //�X�R�A���Z(�����I)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

    //���̖���
    public void KanjiUnionOrder()
    {
        Debug.Log("���̂��܂��B");

        //PossessionKanji.KanjiUnion();

        //PossesionKanji����ł͂Ȃ��A��������������߂��o���Ȃ���΂Ȃ�Ȃ�
        //����������bool�֐����ĂсA�^���o��Ώ�������
        if(PossessionKanji.KanjiUnionCheck())
        {
            DestroyKanji();
        }

    }
}