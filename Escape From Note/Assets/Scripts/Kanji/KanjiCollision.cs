using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //�擾
        if (Input.GetMouseButtonDown(0)) //���N���b�N��
        {
            transform.root.gameObject.GetComponent<KanjiObject>().KanjiGet(); //�e�̃I�u�W�F�N�g��KanjiObject�X�N���v�g�̊֐����Ă�
        }

        //���̖���
        if(Input.GetKeyDown(KeyCode.F))//F�L�[
        {
            transform.root.gameObject.GetComponent<KanjiObject>().KanjiUnionOrder();
        }
    }
}
