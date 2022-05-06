using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk_Yellow : Chalk
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //    player.hp += healAmount;
            player.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            Destroy(this.gameObject);
        }
    }
}
