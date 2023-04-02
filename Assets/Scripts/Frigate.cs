using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Enemy
{
    private Animator anim;
    public GameObject bullet3;


    public override void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        base.Start();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
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
        if (died) return;
        base.OnHit(damage);
        if (hp < 0)
        {
            collider.enabled = false;
            rigid.velocity = Vector2.zero;
            died = true;
            audio.Play();
            anim.SetTrigger("Destroy");
        }
    }
}
