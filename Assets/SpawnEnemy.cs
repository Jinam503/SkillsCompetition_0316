using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] fastSmallSpawnPoints;
    public GameObject[] enemies;
    void Start()
    {
        StartCoroutine(SpawnSmallFast());
    }

    IEnumerator SpawnSmallFast()
    {
        int sP = Random.Range(0, fastSmallSpawnPoints.Length);
        Instantiate(enemies[0], fastSmallSpawnPoints[sP].gameObject.transform.position, fastSmallSpawnPoints[sP].gameObject.transform.rotation);
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        StartCoroutine(SpawnSmallFast());
    }
}
