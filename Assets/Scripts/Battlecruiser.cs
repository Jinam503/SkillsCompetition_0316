using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlecruiser : Enemy
{
    private Animator anim;
    public GameObject bullet1;
    public GameObject bullet2;

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
        for (int i = 0; i < 4; i++)
        {
            
            yield return new WaitForSeconds(0.2f);
            GameObject g = Instantiate(bullet1, transform.position, transform.rotation);
            Rigidbody2D r = g.GetComponent<Rigidbody2D>();
            r.AddForce(Vector2.down * 4f + Vector2.right * -1f, ForceMode2D.Impulse);
        
            GameObject g1 = Instantiate(bullet1, transform.position, transform.rotation);
            Rigidbody2D r1 = g1.GetComponent<Rigidbody2D>();
            r1.AddForce(Vector2.down * 4f, ForceMode2D.Impulse);
        
            GameObject g2 = Instantiate(bullet1, transform.position, transform.rotation);
            Rigidbody2D r2 = g2.GetComponent<Rigidbody2D>();
            r2.AddForce(Vector2.down * 4f + Vector2.right * 1f, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 2; i++)
        {
        
            yield return new WaitForSeconds(0.1f);
            GameObject g = Instantiate(bullet2, transform.position, transform.rotation);
            Rigidbody2D r = g.GetComponent<Rigidbody2D>();
            Vector3 dir = (player.transform.position - transform.position).normalized;
            r.AddForce(dir * 10f, ForceMode2D.Impulse);
        
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 99; i++)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject g = Instantiate(bullet1, transform.position, transform.rotation);
            Rigidbody2D r = g.GetComponent<Rigidbody2D>();
            Vector2 v = new Vector2(Mathf.Sin(Mathf.PI * 10f * (float) i / 99), -1);
            r.AddForce(v.normalized * 8f, ForceMode2D.Impulse);
        }
        
        yield return new WaitForSeconds(3f);
        for (int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < 25; i++)
            {
                GameObject g = Instantiate(bullet1, transform.position, transform.rotation);
                Rigidbody2D r = g.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(Mathf.Sin(Mathf.PI * 2f * (float)i / 25), Mathf.Cos(Mathf.PI * 2f * (float)i / 25));
                r.AddForce(v.normalized *3f, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < 30; i++)
            {
                GameObject g = Instantiate(bullet1, transform.position, transform.rotation);
                Rigidbody2D r = g.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(Mathf.Sin(Mathf.PI * 2f * (float)i / 30), Mathf.Cos(Mathf.PI * 2f * (float)i / 30));
                r.AddForce(v.normalized * 3f, ForceMode2D.Impulse);
            }
        }
        yield return new WaitForSeconds(3f);
        float a = 0f;
        for (int j = 0; j < 20; j++)
        {
            a += 0.2f;
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < 4; i++)
            {
                GameObject g = Instantiate(bullet1, transform.position, transform.rotation);
                Rigidbody2D r = g.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(Mathf.Sin(Mathf.PI * 2f * (float)i / 4 + a), Mathf.Cos(Mathf.PI * 2f * (float)i / 4+a));
                r.AddForce(v.normalized * 5f, ForceMode2D.Impulse);
            }
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
 