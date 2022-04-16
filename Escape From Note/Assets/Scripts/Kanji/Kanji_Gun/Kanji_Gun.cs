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

    //���̌��̊���
    public Kanji_Abstract KanjiSub1; //��
    public Kanji_Abstract KanjiSub2; //�[

    // �e�̔���
    private void LauncherShot()
    {
        
        GameObject player = GameObject.Find("Player");
        firingPoint = player;
        Vector3 direction = player.transform.right;
        direction.Normalize();

        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        bulletPosition.x += direction.x;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, bullet.transform.rotation);
        // �o���������{�[����forward(z������)
     //   Vector3 direction = newBall.transform.right;

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

    //����
    public override void KanjiUnion()
    {

    }

    //����
    public override void KanjiSeparation()
    {
        //�v���C���[���擾
        GameObject player;
        player = GameObject.Find("Player");

        //�����Z�b�g
        player.GetComponent<Player>().KanjiSet(KanjiSub1,false);

        //�[��ݒu
        KanjiSub2.KanjiSummon();
    }
}