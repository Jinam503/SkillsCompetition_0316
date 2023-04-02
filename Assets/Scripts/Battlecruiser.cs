using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlecruiser : Enemy
{
    private Animator anim;
    public GameObject bullet2;
    public GameObject targetPos;

    public override void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        base.Start();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3f);

        //anim.SetTrigger("Fire");
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject g = Instantiate(bullet2, transform.position, transform.rotation);
            Rigidbody2D r = g.GetComponent<Rigidbody2D>();
            r.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
        }

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
 