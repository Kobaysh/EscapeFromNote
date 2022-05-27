using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiItem : KanjiObjectItem
{
    //�����蔻��
    public override void  KanjiGet()
    {
        DestroyKanji();

        //�A�C�e���X���b�g�Ɋi�[
        //Possessionkanji�������Ƀv���C���[�̊֐����Ă�
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiItemSet(PossessionKanji, true);

        //�X�R�A���Z(�����I)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

}
