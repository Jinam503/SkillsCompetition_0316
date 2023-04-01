using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Enemy
{
    private Animator anim;
    public GameObject bullet3;


    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }
    private void Update()
    {
        if (hp > 0)
        {
            transform.Translate(Vector2.up * 1f * Time.deltaTime);
        }
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);

        GameObject g = Instantiate(bullet3, transform.position, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        r.AddForce(Vector3.down * 8f, ForceMode2D.Impulse);

        StartCoroutine(Fire());
    }
    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (hp < 0)
        {
            anim.SetTrigger("Destroy");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
