using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrior : MonoBehaviour
{
    public int hp;

    public void OnHit(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet b = collision.GetComponent<Bullet>();
            OnHit(b.damage);
            Destroy(b.gameObject);
        }
    }
}
