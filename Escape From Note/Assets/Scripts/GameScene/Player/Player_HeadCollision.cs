using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HeadCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("terrain"))
        {
            transform.GetComponentInParent<Player>().JumpPowerReset();
        }

    }
}