using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int enemyScore;
    public int hp;
    SpriteRenderer sp;
    private bool canHit;
    protected new AudioSource audio;
    protected bool died;
    protected Rigidbody2D rigid;
    protected new Collider2D collider;

    

    public GameObject player;
    public virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        died = false;   
        audio = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        canHit = true;
    }
    public virtual void OnHit(int damage)
    {
        if (!canHit) return;
        
        canHit = false;
        hp -= damage;
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a * 0.5f);
        Invoke("ReturnColor", 0.1f);
    }
    public void Destroy()
    {
        Player playerLogic = player.GetComponent<Player>();
        playerLogic.score += enemyScore;
        int itemSpawn = Random.Range(0, 20);
        if (itemSpawn < 3)
        {
            GameObject fuel = Resources.Load<GameObject>("Item/fuel");
            GameObject item = Instantiate(fuel, transform.position, transform.rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
        }
        else if (itemSpawn < 5)
        {
            GameObject fix = Resources.Load<GameObject>("Item/fix");
            GameObject item = Instantiate(fix, transform.position, transform.rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
        }
        itemSpawn = Random.Range(0, 20);
        itemSpawn = 10;
        if (itemSpawn < 3)
        {
            GameObject up = Resources.Load<GameObject>("Item/powerUp");
            GameObject item = Instantiate(up, transform.position, transform.rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
        }
        else if (itemSpawn < 10)
        {
            GameObject point = Resources.Load<GameObject>("Item/point");
            GameObject item = Instantiate(point, transform.position, transform.rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
        }
        else if (itemSpawn < 11)
        {
            GameObject barrior = Resources.Load<GameObject>("Item/barrior");
            GameObject item = Instantiate(barrior, transform.position, transform.rotation);
            Rigidbody2D rigid = item.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
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
        else if(collision.gameObject.tag == "DestroyWall")
        {
            Destroy(gameObject);
        }
    }
}
