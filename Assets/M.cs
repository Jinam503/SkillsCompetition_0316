using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : Enemy
{
    public Vector3 targetPos;
    public GameObject bullet;
    protected override void Awake()
    {
        base.Awake();
        hp = 50;
        bodyDamage = 1;
        StartCoroutine(Fire());
    }
    protected override void Update()
    {
        if(transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        }
        
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        GameObject Aim = transform.GetChild(0).gameObject;
        Vector3 dir = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position - transform.position;
        Aim.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        Instantiate(bullet, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        StartCoroutine(Fire());
    }
}
