using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Enemy
{
    private Animator anim;
    public GameObject bullet_1;


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
            transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
        }
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);
        
        GameObject g = Instantiate(bullet_1, transform.position, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        Vector3 vec =( GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        r.AddForce(vec * 3f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f);

        GameObject g2 = Instantiate(bullet_1, transform.position, transform.rotation);
        Rigidbody2D r2 = g2.GetComponent<Rigidbody2D>();
        Vector3 vec2 = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        r2.AddForce(vec2 * 3f, ForceMode2D.Impulse);

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
