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
