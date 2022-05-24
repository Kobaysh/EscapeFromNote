using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("���F�G�Ƀq�b�g");
            other.GetComponent<Enemy_Type1>().Damage(1);
            //�G�t�F�N�g�Đ�

        }
    }

    public void EffectFinish()
    {
        Destroy(this.gameObject);
    }
    
}
