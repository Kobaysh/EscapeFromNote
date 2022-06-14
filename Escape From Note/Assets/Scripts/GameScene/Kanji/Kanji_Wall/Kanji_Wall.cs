using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Wall")]
public class Kanji_Wall : Kanji_Abstract 
{
 
    // static field

    // public member

    // serialized field
    [SerializeField]
    private GameObject wall_object;
    // private member
    private GameObject wall_instance = null;
    public void Awake() 
    {
    
    }

    public void Start () 
    {
	
	}
	

    public void Update () 
    {
	
	}

	// Action
	public override void KanjiAction()
	{
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if(wall_instance == null)
        {
            Vector3 trans = player.transform.position;
            trans.x += 1.0f * player.transform.right.x;
            trans.y += 0.5f;
            wall_instance = Instantiate<GameObject>(wall_object, trans, new Quaternion());
            wall_instance.transform.SetParent(player.transform);
        }
        else
        {
            Destroy(wall_instance);
            wall_instance = null;
        }
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