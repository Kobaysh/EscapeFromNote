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
            //�G�t�F�N�g�Đ�
        }
    }

    public void EffectFinish()
    {
        Destroy(this.gameObject);
    }
}
