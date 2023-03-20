using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        hp = 1;
        bodyDamage = 1;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * speed;
        
    }
    
}
