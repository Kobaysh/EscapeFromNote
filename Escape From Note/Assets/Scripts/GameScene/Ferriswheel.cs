using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferriswheel : MonoBehaviour
{


    [SerializeField]
    GameObject centerobj;

    float angle = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            //RotateAround(’†S‚ÌêŠ,²,‰ñ“]Šp“x)
            transform.RotateAround(
                centerobj.transform.position,
                Vector3.back,
                angle * Time.deltaTime
                );

    }
}
