using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Scythe")]
public class Kanji_Scythe : Kanji_Abstract 
{

    // static field

    // public member

    // serialized field
    [SerializeField]
    GameObject Collision;
    // private member
    private GameObject Area;
    public void Awake() 
    {
        
    }

    public void Start()
    {

    }
	

    public void Update () 
    {
	
	}

	// Action
	public override void KanjiAction()
	{
        GameObject player = GameObject.Find("Player");
        Vector3 trans = player.transform.position;
        trans.x += 1.0f * Collision.transform.localScale.x / 2 + 0.5f;
        Quaternion rotate = player.transform.rotation;
        //エリアを生成
        Area = (GameObject)Instantiate(Collision, new Vector3(trans.x, trans.y, trans.z), rotate);
        Area.transform.parent = player.transform;
    }

	// unioncheck
    public override bool KanjiUnionCheck()
    {
        return false;
    }

    // separation
    public override void KanjiSeparation()
    {

    }
}