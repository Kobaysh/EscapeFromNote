using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //コリジョンに接触
    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが接触
        if (other.gameObject.CompareTag("Player"))
        {
            //取得
            if (Input.GetKeyDown(KeyCode.K)) //左クリック時
            {
                transform.root.gameObject.GetComponent<KanjiObjectItem>().KanjiGet(); //親のオブジェクトのKanjiObjectスクリプトの関数を呼ぶ
            }

            //合体命令
            if (Input.GetKeyDown(KeyCode.F))//Fキー
            {
                transform.root.gameObject.GetComponent<KanjiObject>().KanjiUnionOrder();
            }
        }
    }
}
