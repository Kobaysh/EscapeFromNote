using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Enemy_Base>().Damage(1);
            Debug.Log("damage by hammer");
            //エフェクト再生
        }
    }

    public void EffectFinish()
    {
        Destroy(this.gameObject);
    }
}
