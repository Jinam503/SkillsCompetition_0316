using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] SPoints;
    public GameObject[] enemies;
    public GameObject[] MPoints;
    void Start()
    {
        StartCoroutine(SpawnS());
        StartCoroutine(SpawnM());
    }

    IEnumerator SpawnS()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        int sP = Random.Range(0, SPoints.Length);
        Instantiate(enemies[0], SPoints[sP].gameObject.transform.position, SPoints[sP].gameObject.transform.rotation);
        StartCoroutine(SpawnS());
    }
    IEnumerator SpawnM()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(SpawnM_());
    }
    IEnumerator SpawnM_()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        
        GameObject enemy = Instantiate(enemies[1], MPoints[0].gameObject.transform.position + Vector3.up * 30, MPoints[0].gameObject.transform.rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        rigid.MovePosition(MPoints[0].gameObject.transform.position);
        yield return new WaitForSeconds(1f);
        GameObject enemy2 =Instantiate(enemies[1], MPoints[1].gameObject.transform.position + Vector3.up * 30, MPoints[1].gameObject.transform.rotation);
        Rigidbody2D rigid2 = enemy2.GetComponent<Rigidbody2D>();
        rigid2.MovePosition(MPoints[0].gameObject.transform.position);
        StartCoroutine(SpawnM_());
    }
}
