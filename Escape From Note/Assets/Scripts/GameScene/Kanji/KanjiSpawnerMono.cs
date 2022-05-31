using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
// �ݒ肵�������̒����烉���_���ň�X�|�[��
public class KanjiSpawnerMono : MonoBehaviour {

    // static field

    // public member

    // serialized field
    [SerializeField, Header("�������X�g")]
    public List<Kanji_Abstract> kanjiList = null;

    [SerializeField, Header("�X�|�[���Ԋu")]
    float interval = 3.0f;
    [SerializeField, Header("���ŊԊu")]
    float disappearance = 3.0f;
    // private member
    private float timer = 0.0f; // �^�C�}�[
    private bool isAppear = false;  // ����Ă��邩
    private GameObject AppearKanji = null;    // ����Ă銿��

    void Awake()
    {

    }

    void Start()
    {
        // �Q�[�����̓G���A�̕`����I�t
        MeshRenderer meshRenderer = null;
        if (TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            meshRenderer.enabled = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        // �������G���A�ɂȂ��ꍇ
        if (!isAppear)
        {
            if (timer >= interval)
            {
                isAppear = true;
                timer = 0.0f;
                int index = Random.Range(0, kanjiList.Count);
                AppearKanji = kanjiList[index].KanjiInstanriate(this.transform.position);                
            }
        }
        // ����������ꍇ
        else
        {
            if (timer >= disappearance)
            {
                isAppear = false;
                timer = 0.0f;

                Destroy(AppearKanji);
                AppearKanji = null;
            }
        }
    }
}