using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Destroy : MonoBehaviour
{

    public string target_tag;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == target_tag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
