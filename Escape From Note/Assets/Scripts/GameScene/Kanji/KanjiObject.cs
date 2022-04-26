using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiObject : MonoBehaviour
{
    private GameObject player;

    //�����Ă��銿��
    public Kanji_Abstract PossessionKanji;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����蔻��
    public void KanjiGet()
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

    //����
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}