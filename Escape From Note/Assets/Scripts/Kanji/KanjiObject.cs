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
        Destroy(gameObject);//�I�u�W�F�N�g������

        //�A�C�e���X���b�g�Ɋi�[
        //Possessionkanji�������Ƀv���C���[�̊֐����Ă�
        player = GameObject.Find("Player");
        player.GetComponent<Player>().KanjiSet(PossessionKanji);
    }

    //���̖���
    public void KanjiUnionOrder()
    {
        Debug.Log("���̂��܂��B");

        PossessionKanji.KanjiUnion();
    }
}