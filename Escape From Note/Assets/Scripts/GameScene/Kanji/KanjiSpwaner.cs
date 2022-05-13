using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// �ݒ肵�������������_���ŕ����X�|�[��
public class KanjiSpwaner : MonoBehaviour {

    // static field

    // public member

    // serialized field
    [SerializeField, Header("�������X�g")]
    private List<Kanji_Abstract> kanjiList = null;

    [SerializeField, Header("�X�|�[���Ԋu")]
    float interval = 3.0f;
    [SerializeField, Header("���ŊԊu")]
    float disappearance = 3.0f;
    [SerializeField, Header("�N���ꏊ")]
    Vector3[] spawnPos;
    // private member
    private float timer = 0.0f; // �^�C�}�[
    private bool isAppear = false;  // ����Ă��邩
    private List<GameObject> AppearKanji = null;    // ����Ă銿��
    
    void Awake() {
        
    }

    void Start () {
        // �Q�[�����̓G���A�̕`����I�t
        GetComponent<MeshRenderer>().enabled = false;
    }
	

    void Update () {
        timer += Time.deltaTime;
        // �������G���A�ɂȂ��ꍇ
        if (!isAppear)
        {
            if (timer >= interval)
            {
                isAppear = true;
                timer = 0.0f;
                AppearKanji = new List<GameObject>();
                for (int i = 0; i < spawnPos.Length; i++)
                {
                    int index = Random.Range(0, kanjiList.Count);
                    AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos[i])));
                }
            }
        }
        // ����������ꍇ
        else
        {
            if (timer >= disappearance)
            {
                isAppear = false;
                timer = 0.0f;

                foreach (var appearList  in AppearKanji)
                {
                   if(appearList != null)
                    {
                        Destroy(appearList);
                    }
                }
                AppearKanji.Clear();
                AppearKanji = null;
            }
        }
	}
}