using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    private Animator anim;
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(hp > 0)
        {
            transform.Translate(Vector2.up * 3f * Time.deltaTime);
        }
    }
    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if(hp < 0)
        {
            anim.SetTrigger("Destroy");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
