using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_PenetrationCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�v���C���[���G��Ă���Ƃ�
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�v���C���[�ђ�");
            //�e�̃I�u�W�F�N�g�̃��C���[��ς���
            transform.root.gameObject.GetComponent<Platform_Penetration>().LayerSwitch(true);
        }
    }
}
