using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int hp;

    public virtual void OnHit(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
