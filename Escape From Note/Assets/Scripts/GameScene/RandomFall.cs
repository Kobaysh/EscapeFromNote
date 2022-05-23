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
        // �g�Q��X���W�𗐐��Ŏ擾
        float posX = GetRandomNum();
        Vector3 pos = new Vector3(0,18,0);
        pos.x = posX;
        needle.transform.position = pos;

        // needle�I�u�W�F�N�g(prefab)�𗐐��łƂ���X���W�ɐ���
        Instantiate(needle, pos, new Quaternion(0,0,0,0));
    }

    float GetRandomNum()
    {
        float num = Random.Range(-11.5f, 11.5f);
        return num;
    }
}
