using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    private Animator anim;
    public override void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        base.Start();
        anim = GetComponent<Animator>();
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
