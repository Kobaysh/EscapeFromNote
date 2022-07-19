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

    [SerializeField]
    private bool isActive;

    private int ActiveTime;
    public int Interval;

    private GameObject Area;

    // Start is called before the first frame update
    public override void Kanji_Start()
    {
        isActive = false;
        Interval = 100;
    }

    // Update is called once per frame
    public override void Kanji_Update()
    {
        if (!isActive)
        {
            return;
        }

        

        if (ActiveTime >= Interval)
        {
            Destroy(Area.gameObject);
            Debug.Log("Stop");
            isActive = false;
        }

        ActiveTime++;
    }

    // action
    public override void KanjiAction()
    {
        isActive = true;
        ActiveTime = 0;
        Debug.Log("Action");
        HammerInstatiate();
        //CoroutineHandler.StartStaticCoroutine(DelayCoroutine());
        
    }

    //unioncheck
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    // separation
    public override void KanjiSeparation()
    {
        // 木

        // 追
    }

    private void HammerInstatiate()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 trans = player.transform.position;
        trans.x += 1.0f * player.transform.right.x;
        trans.y += 0.5f;
        Quaternion rotate = player.transform.rotation;
        // 判定エリア生成
        Area = (GameObject)Instantiate(Collision, new Vector3(trans.x, trans.y, trans.z), rotate);
        Area.transform.parent = player.transform;

        //CoroutineHandler.StopStaticCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        timer += Time.deltaTime;
        if(timer < delay)
        {
            yield return null;
        }

        // 判定生成
        HammerInstatiate();
        
    }
}
