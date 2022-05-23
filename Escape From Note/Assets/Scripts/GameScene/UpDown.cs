using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    [Tooltip("高さの制限")] public float limit;
    private Rigidbody rigid;
    private Vector3 defaultPos;
    public bool flag = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        defaultPos = transform.position;
    }

    void FixedUpdate()
    {
        if (flag)
        {
            // 上移動
            rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, limit), defaultPos.z));
        }
        else
        {
            // 下移動
            rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y - Mathf.PingPong(Time.time, limit), defaultPos.z));
        }

        // 上下変更
        if (transform.position.y == defaultPos.y) flag = !flag;
    }
}
