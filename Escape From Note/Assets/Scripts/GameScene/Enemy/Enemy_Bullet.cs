using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] [Tooltip("�e�̍U����")] private int damage = 1;

    protected float interval = 3.0f;    // �v���C���[���G����
    protected float timer = 0.0f;       // �^�C�}�[�p
    protected bool isCollided = false;  // �����蔻��p

    // Start is called before the first frame update
    void Start()
    {
        // �o���������{�[����1.0�b��ɏ���
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0.0f;
                isCollided = false;
            }
        }
    }

    // Player�ƏՓˎ�
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy bullet hit");

        if (other.gameObject.CompareTag("Player"))
        {
            if (!isCollided)
            {
                Debug.Log("damage");
                isCollided = true;
                timer = 0.0f;

                GameObject.Find("Player").GetComponent<Player>().Damage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
