using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRope : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�R")]
    private GameObject rope;

    [SerializeField]
    [Tooltip("Rigidbody�t�^�Ώ�")]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        CheckRopeExists();
    }

    public void CheckRopeExists()
    {
        // ���[�v�����݂���ꍇ
        if (rope)
        {
            // �������Ȃ�
        }
        // ���[�v�����݂��Ȃ��ꍇ
        else
        {
            // target���Q�[���V�[����ɂ���ꍇ
            if(target)
            { 

                var component = target.GetComponent<Rigidbody>();

                // Rigidbody���t�^����Ă��Ȃ�������
                if (component == null)
                {
                    // �ytarget�z��RigidBody��t�^
                    Rigidbody rigidbody = target.AddComponent<Rigidbody>();
                }
            }
        }
    }
}
