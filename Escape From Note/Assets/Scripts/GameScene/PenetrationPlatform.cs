using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrationPlatform : MonoBehaviour
{
    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = transform.parent.gameObject; //一つ親のオブジェクト
    }

    // Update is called once per frame
    void Update()
    {

    }

    //コリジョンに触れられたとき
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //レイヤーを変更する
            Debug.Log("貫通");
            root.gameObject.layer = LayerMask.NameToLayer("PlatformPenetration");
            //レイヤー「Player」のオブジェクトと「PlatformPenetration」のオブジェクトは衝突判定を取らない
        }
    }

    //コリジョンが離れた時
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("貫通解除");
            root.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
