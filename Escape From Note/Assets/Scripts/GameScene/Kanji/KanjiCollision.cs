using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KanjiCollision : MonoBehaviour
{
    private bool IA_TakeKanji = false;
    private bool IA_UnionKanji = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IA_TakeKanji) IA_TakeKanji = false;
        if (IA_UnionKanji) IA_UnionKanji = false;
    }

    //コリジョンに接触
    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが接触
        if (other.gameObject.CompareTag("Player"))
        {
            //取得
  //          if (Input.GetKeyDown(KeyCode.K)) //左クリック時
            if (IA_TakeKanji) //左クリック時
            {
                IA_UnionKanji = false;
                transform.root.gameObject.GetComponent<KanjiObjectItem>().KanjiGet(); //親のオブジェクトのKanjiObjectスクリプトの関数を呼ぶ
            }

            //合体命令
 //           if (Input.GetKeyDown(KeyCode.F))//Fキー
            if (IA_UnionKanji)//Fキー
            {
                IA_UnionKanji = false;
                transform.root.gameObject.GetComponent<KanjiObject>().KanjiUnionOrder();
            }
        }
    }


}
