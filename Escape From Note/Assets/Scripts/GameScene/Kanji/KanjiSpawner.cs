using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 設定した漢字をランダムで複数スポーン
public class KanjiSpwaner : MonoBehaviour {

    // static field

    // public member

    // serialized field
    [SerializeField, Header("漢字リスト")]
    private List<Kanji_Abstract> kanjiList = null;

    [SerializeField, Header("スポーン間隔")]
    float interval = 3.0f;
    [SerializeField, Header("消滅間隔")]
    float disappearance = 3.0f;
    [SerializeField, Header("湧く場所")]
    Vector3[] spawnPos;
    // private member
    private float timer = 0.0f; // タイマー
    private bool isAppear = false;  // 現れているか
    private List<GameObject> AppearKanji = null;    // 現れてる漢字
    
    void Awake() {
        
    }

    void Start () {
        // ゲーム中はエリアの描画をオフ
        MeshRenderer meshRenderer = null; 
        if(TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            meshRenderer.enabled = false;
        }
    }
	

    void Update () {
        timer += Time.deltaTime;
        // 漢字がエリアにない場合
        if (!isAppear)
        {
            if (timer >= interval)
            {
                isAppear = true;
                timer = 0.0f;
                AppearKanji = new List<GameObject>();
                for (int i = 0; i < spawnPos.Length; i++)
                {
                    int index = Random.Range(0, kanjiList.Count);
                    AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos[i])));
                }
            }
        }
        // 漢字がある場合
        else
        {
            if (timer >= disappearance)
            {
                isAppear = false;
                timer = 0.0f;

                foreach (var appearList  in AppearKanji)
                {
                   if(appearList != null)
                    {
                        Destroy(appearList);
                    }
                }
                AppearKanji.Clear();
                AppearKanji = null;
            }
        }
	}
}