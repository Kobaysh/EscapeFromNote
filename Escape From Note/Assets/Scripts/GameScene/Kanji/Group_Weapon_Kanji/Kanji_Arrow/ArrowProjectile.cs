using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowProjectile : MonoBehaviour 
{

    // static field

    // public member

    // serialized field
    [SerializeField]
    private float range;
    [SerializeField]
    private float limitTime;
    [SerializeField]
    private float speed;
    // private member
    private float timer;
    public void Awake() 
    {
        
    }

    public void Start () 
    {
        timer = 0.0f;
	}
	

    public void Update () 
    {
	    timer += Time.deltaTime;
        if(timer >= limitTime)
        {
            Destroy(this.gameObject);
            return;
        }
	}

    public void FixedUpdate() 
    {


    }

    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}