using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Weapon_Collision : MonoBehaviour 
{
 
    [SerializeField]
    private int damageAmount = 1;
        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Enemy_Base>().Damage(damageAmount);
            
            //エフェクト再生
        }
    }

    public void EffectFinish()
    {
        Destroy(this.gameObject);
    }
}