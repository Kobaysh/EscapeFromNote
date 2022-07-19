using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Enemy_Base>().Damage(1);
            
            //エフェクト再生
        }
    }

    public void EffectFinish()
    {
        Destroy(this.gameObject);
    }
    
}
