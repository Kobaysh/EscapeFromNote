using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField, Header("�G���X�g")]
    private List<Enemy_Object> enemies = null;
    [SerializeField, Header("�X�|�[���Ԋu")]
    private float spawnInterval = 3.0f;

    [SerializeField]
    private GameManager gameManager = null;

    private float timer;
    private static int nowEnemyNum;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        nowEnemyNum = 0;
        if (!gameManager) gameManager =  GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.GetMaxEnemy() <= 0)
        {
            Debug.LogAssertionFormat("Ememy_Spawner.cs:�ő�G����o�^���Ă�������:{0}", gameManager.gameObject.name);
        }
        if (enemies.Count <= 0)
            Debug.LogAssertionFormat("Ememy_Spawner.cs:�G���X�g��o�^���Ă�������:{0}", this.gameObject.name);

        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            timer = 0.0f;
            if (CheckMaxEnemy())
            {
                SpawnEnemy();
            //    nowEnemyNum++;
                CountEnemy();
            }
            else
            {
                Debug.LogFormat("Ememy_Spawner.cs:�G�̐����ő�ł��B");
            }
        }

    }

    private void SpawnEnemy(Vector3 pos)
    {
        int randomIndex = this.GetRandomNumEnemies();
        Instantiate(enemies[randomIndex], pos, new Quaternion());
    }

    private void SpawnEnemy()
    {
        int randomIndex = this.GetRandomNumEnemies();
        Instantiate(enemies[randomIndex], transform.position, new Quaternion());
    }

    private int GetRandomNumEnemies()
    {
        return Random.Range(0, enemies.Count);
    }

    private bool CheckMaxEnemy()
    {
        if (!gameManager) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        return (nowEnemyNum >= 0 && nowEnemyNum < gameManager.GetMaxEnemy());
    }

    private void CountEnemy()
    {
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        nowEnemyNum = enemies.Length;
    }
}
