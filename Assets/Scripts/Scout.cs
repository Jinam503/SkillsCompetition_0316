using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Enemy
{
    private Animator anim;
    public GameObject bullet2;

    public override void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        base.Start();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject g = Instantiate(bullet2, transform.position, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        Vector3 vec = (player.transform.position - transform.position).normalized;
        r.AddForce(vec * 6f, ForceMode2D.Impulse);
    }
    public override void OnHit(int damage)
    {
        if (died) return;
        base.OnHit(damage);
        if (hp < 0)
        {
            collider.enabled = false;
            rigid.velocity = Vector2.zero;
            StopAllCoroutines();
            died = true;
            audio.Play();
            anim.SetTrigger("Destroy");
        }
    }
}
