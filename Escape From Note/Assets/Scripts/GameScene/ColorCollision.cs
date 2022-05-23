using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollision : MonoBehaviour
{

    private GameObject player;
    private Color M_plat;

    // Start is called before the first frame update
    void Start()
    {
        M_plat = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       Color M_player = player.GetComponent<Renderer>().material.color;

        if (M_plat == M_player)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
