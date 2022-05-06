using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour
{
    [SerializeField]
    protected int healAmount = 1;
    [SerializeField]
    protected Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.hp += healAmount;
            player.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            Destroy(this.gameObject);
        }
    }
}
