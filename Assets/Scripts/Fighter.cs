using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Enemy
{
    private Animator anim;
    public GameObject bullet_1;


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
        GameObject g = Instantiate(bullet_1, transform.position + Vector3.right * 0.3f, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        Vector3 vec =( player.transform.position - transform.position).normalized;
        r.AddForce(vec * 3f, ForceMode2D.Impulse);

        GameObject g2 = Instantiate(bullet_1, transform.position + Vector3.right * -0.3f, transform.rotation);
        Rigidbody2D r2 = g2.GetComponent<Rigidbody2D>();
        Vector3 vec2 = (player.transform.position - transform.position).normalized;
        r2.AddForce(vec2 * 3f, ForceMode2D.Impulse);

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
            StopAllCoroutines();
            died = true;
            audio.Play();
            anim.SetTrigger("Destroy");
        }
    }
}
