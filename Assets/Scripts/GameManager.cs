using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;

    public bool isEnd;

    public Image[] lifeImages;
    public GameObject GameOver;
    public Text scoreText;
    public GameObject player;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnEnemy_());
        StartCoroutine(SpawnEnemy__());
        isEnd = false;
    }
    private void Update()
    {
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        int spawnPoint = Random.Range(0, 5);
        int enemytype = Random.Range(0, 3);
        GameObject enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0,0,180));
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy_()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        int spawnPoint = Random.Range(0, 2);
        GameObject enemy = Instantiate(enemyPrefab[4], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
        StartCoroutine(SpawnEnemy_());
    }
    IEnumerator SpawnEnemy__()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        int spawnPoint = Random.Range(5, 11);
        int enemytype = Random.Range(2, 4);
        GameObject enemy;
        if(spawnPoint < 8)
        {
            enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(enemyLogic.speed ,-1);
        }
        else
        {
            enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(enemyLogic.speed * -1,-1);
        }
        
        
        StartCoroutine(SpawnEnemy__());
    }
    public void UpdateLife(int life)
    {
        if(life == 0)
        {
            isEnd = true;
            GameOver.gameObject.SetActive(true);
        }
        for(int i = 0; i < 3; i++)
        {
            lifeImages[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < life; i++)
        {
            lifeImages[i].color = new Color(1, 1, 1, 1);
        }
    }
    public void Retry()
    {
        isEnd = true;
        GameOver.SetActive(false);
        player.gameObject.SetActive(true);
        player.GetComponent<Player>().life = 3;
        UpdateLife(3);
        player.transform.position = new Vector3(0, -3, 0);
    }
}
