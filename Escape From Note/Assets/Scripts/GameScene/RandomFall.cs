using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFall : MonoBehaviour
{
    [SerializeField]
    GameObject needle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetNeedle", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetNeedle()
    {
        // トゲのX座標を乱数で取得
        float posX = GetRandomNum();
        Vector3 pos = new Vector3(0,18,0);
        pos.x = posX;
        needle.transform.position = pos;

        // needleオブジェクト(prefab)を乱数でとったX座標に生成
        Instantiate(needle, pos, new Quaternion(0,0,0,0));
    }

    float GetRandomNum()
    {
        float num = Random.Range(-11.5f, 11.5f);
        return num;
    }
}
