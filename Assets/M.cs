using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        hp = 50;
        bodyDamage = 1;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

    }
}
