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
    public GameObject meteorPrefab;
    public Text[] scores;
    public Text[] times;

    public static bool StartMBoss;
    public static bool StartLBoss;
    public static bool ClearMBoss;
    public static bool ClearLBoss;

    private void Start()
    {
        StartMBoss = false;
        StartLBoss = false;
        ClearMBoss =false;
        ClearLBoss = false;
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnEnemy_");
        StartCoroutine("SpawnEnemy__");
        StartCoroutine("SpawnMeteor");
        isEnd = false;
    }
    private void Update()
    {
        Debug.Log(StartMBoss);
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
        if (playerLogic.score > 25000 && !StartMBoss && !ClearMBoss) {
            StartMBoss = true;
            GameObject enemy = Instantiate(enemyPrefab[5], spawnPoints[2].position, Quaternion.Euler(0, 0, 180));
            Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
            Enemy enemyLogic = enemy.GetComponent<Enemy>();
            enemyLogic.player = player;
            rigid.velocity = new Vector2(0, enemyLogic.speed * -1);
            StartCoroutine(StopMove(rigid));
        }
        else if (playerLogic.score > 50000 && !StartLBoss && !ClearLBoss)
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
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        if (!StartMBoss && !StartLBoss)
        {
            
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
    IEnumerator SpawnMeteor()
    {
        yield return new WaitForSeconds(Random.Range(8f, 10f)); 
        GameObject m = Instantiate(meteorPrefab, spawnPoints[2].transform.position, Quaternion.identity);
        Meteor mL = m.GetComponent<Meteor>();
        mL.player = player;
        StartCoroutine("SpawnMeteor");
    }

    public void UpdateLife(int life)
    {
        if(life == 0)
        {
            isEnd = true;
            Player p = player.GetComponent<Player>();
            ScoreInfo info = new ScoreInfo();
            info.time = p.playTime;
            info.name = "player";
            info.score = p.score;
            Ranking.list.Add(info);
            Ranking.SortList();
            List<ScoreInfo> l = Ranking.list;
            for(int i = 0; i < l.Count; i++)
            {
                scores[i].text = l[i].score.ToString();
                times[i].text = l[i].time.ToString();
            }
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
    public void Out()
    {
        SceneManager.LoadScene("PickStage");
    }
}
