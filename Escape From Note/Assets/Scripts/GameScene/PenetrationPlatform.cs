using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrationPlatform : MonoBehaviour
{
    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = transform.parent.gameObject; //��e�̃I�u�W�F�N�g
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�R���W�����ɐG���ꂽ�Ƃ�
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //���C���[��ύX����
            Debug.Log("�ђ�");
            root.gameObject.layer = LayerMask.NameToLayer("PlatformPenetration");
            //���C���[�uPlayer�v�̃I�u�W�F�N�g�ƁuPlatformPenetration�v�̃I�u�W�F�N�g�͏Փ˔�������Ȃ�
        }
    }

    //�R���W���������ꂽ��
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�ђʉ���");
            root.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
