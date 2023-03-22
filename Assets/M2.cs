using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2 : Enemy
{ 
    public GameObject bullet;
    private Rigidbody2D rigid;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
        hp = 20;
        bodyDamage = 1;
        
        StartCoroutine(Fire());
    }
    protected override void Update()
    {

    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        Vector2 v1 = new Vector2(transform.position.x + 0.3f, transform.position.y);
        Vector2 v2 = new Vector2(transform.position.x - 0.3f, transform.position.y);
        Instantiate(bullet, v1, transform.rotation);
        Instantiate(bullet, v2, transform.rotation);

        StartCoroutine(Fire());
    }
}
