using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    SpriteRenderer sp;
    private bool canHit;

    public virtual void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        canHit = true;
    }
    public virtual void OnHit(int damage)
    {
        if (!canHit) return;
        canHit = false;
        hp -= damage;
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a * 0.5f);
        Invoke("ReturnColor", 0.05f);
    }
    void ReturnColor()
    {
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a * 2f);
        canHit = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Bullet b = collision.GetComponent<Bullet>();
            OnHit(b.damage);
            Destroy(b.gameObject);
        }
    }
}
