using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Assets/Kanji Scriptable/Kanji_Bow")]
public class Kanji_Bow : Kanji_Abstract
{

    // static field

    // public member

    // serialized field
    [SerializeField]
    private GameObject arrowProjectile;
    [SerializeField]
    private float speed;
    // private member

    public override void Kanji_Start()
    {
    }

    // Update is called once per frame
    public override void Kanji_Update()
    {

    }

    // Action
    public override void KanjiAction()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Vector3 pos = player.transform.position;
        pos.x += player.transform.right.x + 0.5f;
        GameObject arrow =
        Instantiate(arrowProjectile, pos, new Quaternion());
        arrow.transform.right = player.transform.right;
        arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.right * speed, ForceMode.Impulse);
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