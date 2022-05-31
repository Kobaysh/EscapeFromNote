using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Tooltip("’e‚ÌUŒ‚—Í")] private int damage = 1;

    private string enemy_name;

    // Start is called before the first frame update
    void Start()
    {
        // oŒ»‚³‚¹‚½ƒ{[ƒ‹‚ğ1.0•bŒã‚ÉÁ‚·
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Enemy‚ÆÕ“Ë
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy bullet hit");

        if (other.gameObject.CompareTag("enemy"))
        {
            enemy_name = other.gameObject.name;

            GameObject.Find(enemy_name).GetComponent<Enemy_Base>().Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
