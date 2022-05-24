using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour
{
    public enum Chalk_Color
    {
        CHALK_WHITE,
        CHALK_YELLOW,
        CHALK_RED,
        CHALK_BLUE,
    }
    [SerializeField]
    private Chalk_Color chalkColor = Chalk_Color.CHALK_WHITE;
    [SerializeField]
    protected int healAmount = 1;
    [SerializeField]
    protected Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        switch (chalkColor)
        {
            case Chalk_Color.CHALK_WHITE:
                this.GetComponent<MeshRenderer>().material.color = Color.white;
                break;
            case Chalk_Color.CHALK_YELLOW:
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case Chalk_Color.CHALK_RED:
                this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.6f, 0.9f, 1.0f);
                break;
            case Chalk_Color.CHALK_BLUE:
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            default: break;
        }

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
            //player.ChangeColorみたいな関数で引数をChalk_Colorしてプレイヤーの色を変える
            Destroy(this.gameObject);
        }
    }
}
