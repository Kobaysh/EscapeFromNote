using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// �ݒ肵�������������_���ŕ����X�|�[��
public class KanjiSpawner : MonoBehaviour {

    // static field

    // public member

    // serialized field
    [SerializeField, Header("�������X�g")]
    private List<Kanji_Abstract> kanjiList = null;

    [SerializeField, Header("�X�|�[���Ԋu")]
    float interval = 3.0f;
    [SerializeField, Header("���ŊԊu")]
    float disappearance = 3.0f;
    [SerializeField, Header("�N����")]
    int spawnNum;
    // private member
    private float timer = 0.0f; // �^�C�}�[
    private bool isAppear = false;  // ����Ă��邩
    private List<GameObject> AppearKanji = null;    // ����Ă銿��
    private Rect spawnRect; // �N���ꏊ
    
    void Awake() {
        
    }

    void Start () {
        // �Q�[�����̓G���A�̕`����I�t
        MeshRenderer meshRenderer = null; 
        if(TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            meshRenderer.enabled = false;
        }
        spawnRect = GetComponent<VisuallyEditor.VisuallyEditableRect>().Rect;
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
                for (int i = 0; i < spawnNum; i++)
                {
                    int index = Random.Range(0, kanjiList.Count);
                    Vector3 spawnPos;
                    spawnPos.z = 0.0f;
                    spawnPos.x = Random.Range(spawnRect.xMin, spawnRect.xMax);
                    spawnPos.y = Random.Range(spawnRect.yMin, spawnRect.yMax);
                    AppearKanji.Add((kanjiList[index].KanjiInstanriate(spawnPos)));
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