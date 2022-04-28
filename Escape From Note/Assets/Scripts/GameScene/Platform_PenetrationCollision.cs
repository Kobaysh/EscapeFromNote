using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_PenetrationCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが触れているとき
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("プレイヤー貫通");
            //親のオブジェクトのレイヤーを変える
            transform.root.gameObject.GetComponent<Platform_Penetration>().LayerSwitch(true);
        }
    }
}
