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
        yield return new WaitForSeconds(1f);
        int sP = Random.Range(0, SPoints.Length);
        Instantiate(enemies[0], SPoints[sP].gameObject.transform.position, SPoints[sP].gameObject.transform.rotation);
        StartCoroutine(SpawnS());
    }
    IEnumerator SpawnM()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnM_());
    }
    IEnumerator SpawnM_()
    {
        
        GameObject enemy = Instantiate(enemies[1], MPoints[0].gameObject.transform.position + Vector3.up * 3, MPoints[0].gameObject.transform.rotation);
        M m = enemy.GetComponent<M>();
        m.targetPos = MPoints[0].gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        GameObject enemy2 = Instantiate(enemies[1], MPoints[1].gameObject.transform.position + Vector3.up * 3, MPoints[1].gameObject.transform.rotation);
        M m2 = enemy2.GetComponent<M>();
        m2.targetPos = MPoints[1].gameObject.transform.position; 
        //StartCoroutine(SpawnM_());
    }
}
