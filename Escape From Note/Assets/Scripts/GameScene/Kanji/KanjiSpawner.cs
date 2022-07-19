using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 設定した漢字をランダムで複数スポーン
public class KanjiSpawner : MonoBehaviour {

    // static field

    // public member

    // serialized field
    [SerializeField, Header("漢字リスト")]
    private List<Kanji_Abstract> kanjiList = null;

    [SerializeField, Header("スポーン間隔")]
    float interval = 3.0f;
    [SerializeField, Header("消滅間隔")]
    float disappearance = 3.0f;
    [SerializeField, Header("湧く数")]
    int spawnNum;
    // private member
    private float timer = 0.0f; // タイマー
    private bool isAppear = false;  // 現れているか
    private List<GameObject> AppearKanji = null;    // 現れてる漢字
    private Rect spawnRect; // 湧く場所
    
    void Awake() {
        
    }

    void Start () {
        // ゲーム中はエリアの描画をオフ
        MeshRenderer meshRenderer = null; 
        if(TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            meshRenderer.enabled = false;
        }
        spawnRect = GetComponent<VisuallyEditor.VisuallyEditableRect>().Rect;
    }
	

    void Update () {
        timer += Time.deltaTime;
        // 漢字がエリアにない場合
        if (!isAppear)
        {
            if (timer >= interval)
            {
                Spawn();
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

    private void Spawn()
    {
        Vector3 scale = this.transform.localScale * 1.1f;
        scale.z = 0.0f;
        isAppear = true;
        timer = 0.0f;
        AppearKanji = new List<GameObject>();
        Vector3[] ApVec = new Vector3[spawnNum];
        // for (int i = 0; i < spawnNum; i++)
        // {
        //     int index = Random.Range(0, kanjiList.Count);
        //     Vector3 spawnPos;
        //     spawnPos.z = 0.0f;
        //     spawnPos.x = Random.Range(spawnRect.xMin, spawnRect.xMax);
        //     spawnPos.y = Random.Range(spawnRect.yMin, spawnRect.yMax);
        //     AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos)));
        // }
        int i = 0;
        while (true)
        {
            int rec = 0;
            int index = Random.Range(0, kanjiList.Count);
            Vector3 spawnPos;
            spawnPos.z = 0.0f;
            spawnPos.x = Random.Range(spawnRect.xMin, spawnRect.xMax);
            spawnPos.y = Random.Range(spawnRect.yMin, spawnRect.yMax);
            if (i == 0)
            {
                AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos)));
                ApVec[i] = spawnPos;
                i++;
                continue;
            }
            for (int j = 0;j < i ;j++)
            {

                Vector3 vec = ApVec[j] - spawnPos;
                if(vec.sqrMagnitude > scale.sqrMagnitude * 2)
                {
                    rec++;

                }
                if(rec > i)
                {
                    AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos)));
                    ApVec[i] = spawnPos;
                    i++;
                    break;
                }
                //if((spawnPos.x - scale.x > ApVec[j].x + scale.x || spawnPos.x + scale.x < ApVec[j].x - scale.x) &&
                //(spawnPos.y - scale.y > ApVec[j].y + scale.y || spawnPos.y + scale.y < ApVec[j].y - scale.y))
                //{
                //    AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos)));
                //    ApVec[i] = spawnPos;
                //    i++;
                //    break;
                //}
                Debug.Log("被り");
            }
            if (i >= spawnNum) break;
        }
    }
}