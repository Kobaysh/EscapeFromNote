using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    [Tooltip("�����̐���")] public float limit;
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
            // ��ړ�
            rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, limit), defaultPos.z));
        }
        else
        {
            // ���ړ�
            rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y - Mathf.PingPong(Time.time, limit), defaultPos.z));
        }

        // �㉺�ύX
        if (transform.position.y == defaultPos.y) flag = !flag;
    }
}
