using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Assets/Kanji Scriptable/Kanji_Spear")]
public class Kanji_Spear : Kanji_Abstract
{
    [SerializeField]
    private GameObject Collision;

    private bool isActive;
    private int ActiveTime;
    public int Interval;
    

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        //���Ԍo�߂ŏI��
        if(ActiveTime>=Interval)
        {

            isActive = false;
        }

        ActiveTime++;
    }

    //�A�N�V����
    public override void KanjiAction()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 trans = player.transform.position;
        Quaternion rotate = player.transform.rotation;
        //�G���A�𐶐�
        Instantiate(Collision,new Vector3(trans.x,trans.y,trans.z),rotate);
    }

    //���̉۔���
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    //����
    public override void KanjiSeparation()
    {
        //��

        //�q
    }
}
