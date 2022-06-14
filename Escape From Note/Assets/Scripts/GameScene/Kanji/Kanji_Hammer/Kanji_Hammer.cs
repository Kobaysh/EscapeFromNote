using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Hammer")]
public class Kanji_Hammer : Kanji_Abstract
{
    [SerializeField]
    private GameObject Collision;
    [SerializeField]
    private float delay = 0.5f;

    private float timer = 0.0f;
    private bool isActive;
    private int ActiveTime;
    public int Interval;

    private GameObject Area;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }


        //���Ԍo�߂ŏI��
        if (ActiveTime >= Interval)
        {

            isActive = false;
        }

        ActiveTime++;
    }

    //�A�N�V����
    public override void KanjiAction()
    {
        CoroutineHandler.StartStaticCoroutine(DelayCoroutine());
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

        //��
    }

    private void HammerInstatiate()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 trans = player.transform.position;
        trans.x += 1.0f * player.transform.right.x;
        trans.y += 0.5f;
        Quaternion rotate = player.transform.rotation;
        //�G���A�𐶐�
        Area = (GameObject)Instantiate(Collision, new Vector3(trans.x, trans.y, trans.z), rotate);
        Area.transform.parent = player.transform;

        CoroutineHandler.StopStaticCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        timer += Time.deltaTime;
        if(timer < delay)
        {
            yield return null;
        }

        // �f�B���C�I����
        HammerInstatiate();
        
    }
}
