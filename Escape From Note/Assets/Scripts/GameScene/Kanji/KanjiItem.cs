using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiItem : MonoBehaviour
{
    private GameObject player;

    //�����Ă��銿��
    public Kanji_Abstract PossessionKanji;

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
     //   player.GetComponent<Player>().KanjiSet(PossessionKanji, true);

        //�X�R�A���Z(�����I)
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().GameScore += 10;
    }

    //����
    public void DestroyKanji()
    {
        Destroy(gameObject);
    }
}
