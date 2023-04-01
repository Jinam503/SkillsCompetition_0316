using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Enemy
{
    private Animator anim;
    public GameObject bullet2;


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
            transform.Translate(Vector2.up * 4f * Time.deltaTime);
        }
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);

        GameObject g = Instantiate(bullet2, transform.position, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        Vector3 vec = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        r.AddForce(vec * 3f, ForceMode2D.Impulse);
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
