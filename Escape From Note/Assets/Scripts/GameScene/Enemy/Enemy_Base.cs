using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    // �G�l�~�[�����X�e�[�^�X
    protected int    hp;                // �̗�  
    protected float  speed;             // �ړ����x
    protected int    damage;            // �U����
    protected Player player;            //�v���C���[���

    // �G�Ƃ̔���p
    protected float interval;           // �Ԋu
    protected float timer = 0.0f;       // �^�C�}�[�p
    protected bool isCollided = false;  // �����蔻��p

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
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

    public virtual void Attack()
    {
    }

    public virtual void Move()
    {
    }

    //// �G�ƏՓˎ�
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (!isCollided)
    //        {
    //            Debug.Log("damage");
    //            isCollided = true;
    //            timer = 0.0f;
    //            Player player = other.GetComponent<Player>();
    //            player.hp -= damage;
    //            if (player.hp <= 0)
    //            {
    //                player.hp = 0;
    //            }
    //        }
    //    }
    //}
}
