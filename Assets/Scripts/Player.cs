using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    private float h;
    private float v;
    public float moveSpeed;

    public GameObject playerBullet_1;
    public GameObject playerBullet_2;
    public GameObject playerBullet_3;

    public float maxShootDelay;
    public float curShootDelay = 0f;

    public int BulletLvl;

    private bool touchL;
    private bool touchR;
    private bool touchT;
    private bool touchB;

    public int life;

    private bool canDamage;
    private SpriteRenderer sr;

    public GameManager gameManager;
    private void Start()
    {
        canDamage = true;
        sr = GetComponent<SpriteRenderer>();
        life = 3;
        gameManager.UpdateLife(life);
    }
    private void Update()
    {
        Inputs();
        Move();
        Fire();
    }
    private void Fire()
    {
        ShootDelay();
        if (curShootDelay < maxShootDelay) return;
        curShootDelay = 0f;
        Quaternion rot = Quaternion.Euler(0, 0, 90);
        switch (BulletLvl)
        {
            case 1:
                GameObject b1 = Instantiate(playerBullet_1, transform.position, rot);
                Rigidbody2D r1 = b1.GetComponent<Rigidbody2D>();
                r1.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject b2 = Instantiate(playerBullet_2, transform.position, rot);
                Rigidbody2D r2 = b2.GetComponent<Rigidbody2D>();
                r2.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject b3 = Instantiate(playerBullet_3, transform.position, rot);
                Rigidbody2D r3 = b3.GetComponent<Rigidbody2D>();
                r3.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
                break;
        }
        
    }
    private void ShootDelay()
    {
        curShootDelay += Time.deltaTime;
    }
    private void Move()
    {
        Vector3 nextpos = new Vector3(h, v, 0);
        transform.position = transform.position + nextpos * moveSpeed * Time.deltaTime;
    }
    private void Inputs()
    {
        h = Input.GetAxisRaw("Horizontal");
        if ((h == 1 && touchR) || (h == -1 && touchL)) h = 0;
        v = Input.GetAxisRaw("Vertical");
        if ((v == 1 && touchT) || (v == -1 && touchB)) v = 0;
    }
    private void Respawn()
    {
        sr.color = new Color(1, 1, 1, 1);
        canDamage = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWall")
        {
            switch (collision.gameObject.name)
            {
                case "L":
                    touchL = true;
                    break;
                case "R":
                    touchR = true;
                    break;
                case "T":
                    touchT = true;
                    break;
                case "B":
                    touchB = true;
                    break;

            }
        }
        else if(collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if (!canDamage) return;
            life--;
            if(life == 0)
            {
                gameObject.SetActive(false);
            }
            gameManager.UpdateLife(life);
            sr.color = new Color(1, 1, 1, 0.5f);
            canDamage = false;
            Invoke("Respawn", 2f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWall")
        {
            switch (collision.gameObject.name)
            {
                case "L":
                    touchL = false;
                    break;
                case "R":
                    touchR = false;
                    break;
                case "T":
                    touchT = false;
                    break;
                case "B":
                    touchB = false;
                    break;

            }
        }
    }
}
