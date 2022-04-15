using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�p���N���X
[CreateAssetMenu(menuName="Assets/Kanji Scriptable/Kanji_Gun")]
public class Kanji_Gun : Kanji_Abstract
{
    private GameObject firingPoint;

    [SerializeField, Header("�e")]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 20f;

	/// �e�̔���
    private void LauncherShot()
    {
        
        GameObject player = GameObject.Find("Player");
        firingPoint = player;

        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        bulletPosition.x += 1.0f;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, bullet.transform.rotation);
        // �o���������{�[����forward(z������)
        Vector3 direction = newBall.transform.right;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����1.5�b��ɏ���
        Destroy(newBall, 1.5f);
    }

    //�A�N�V����
    public override void KanjiAction()
    {
        Debug.Log("�e");

        // �e�𔭎˂���
        LauncherShot();
       
    }
}