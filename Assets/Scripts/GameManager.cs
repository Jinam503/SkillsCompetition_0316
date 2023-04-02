using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private bool StartMBoss = false;
    private bool StartLBoss = false;

    private void Start()
    {
        //StartCoroutine("SpawnEnemy");
        //StartCoroutine("SpawnEnemy_");
        //StartCoroutine("SpawnEnemy__");
        isEnd = false;
    }
    private void Update()
    {
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
        if (playerLogic.score > 25000 && !StartMBoss) {
            StartMBoss = true;
            GameObject enemy = Instantiate(enemyPrefab[5], spawnPoints[2].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
            StartCoroutine(StopMove(rigid));
        }
        else if (playerLogic.score > 50000 && !StartLBoss)
        {
            StartLBoss = true;
            GameObject enemy = Instantiate(enemyPrefab[6], spawnPoints[2].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
            StartCoroutine(StopMove(rigid));
        }
    }
    IEnumerator StopMove(Rigidbody2D r)
    {
        yield return new WaitForSeconds(3f);
        r.velocity = Vector2.zero;
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (!StartMBoss && !StartLBoss )
        {
            int spawnPoint = Random.Range(0, 5);
            int enemytype = Random.Range(0, 3);
            GameObject enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
        }
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy_()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        if (!StartMBoss && !StartLBoss)
        {
            int spawnPoint = Random.Range(0, 2);
            GameObject enemy = Instantiate(enemyPrefab[4], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
        }
        StartCoroutine(SpawnEnemy_());
    }
    IEnumerator SpawnEnemy__()
    {
        if (!StartMBoss && !StartLBoss)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            int spawnPoint = Random.Range(5, 11);
            int enemytype = Random.Range(2, 4);
            GameObject enemy;
            if (spawnPoint < 8)
            {
                enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
                Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
                Enemy enemyLogic = enemy.GetComponent<Enemy>();
                enemyLogic.player = player;
                rigid.velocity = new Vector2(enemyLogic.speed, -1);
            }
            else
            {
                enemy = Instantiate(enemyPrefab[enemytype], spawnPoints[spawnPoint].position, Quaternion.Euler(0, 0, 180));
                Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
                Enemy enemyLogic = enemy.GetComponent<Enemy>();
                enemyLogic.player = player;
                rigid.velocity = new Vector2(enemyLogic.speed * -1, -1);
            }
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
        SceneManager.LoadScene("Stage 1");
    }
}
