using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int score;
    public float fuel;

    public Image fuelImage;

    private bool canDamage;
    private SpriteRenderer sr;

    public GameManager gameManager;
    private void Start()
    {
        canDamage = true;
        sr = GetComponent<SpriteRenderer>();
        life = 3;
        fuel = 100;
        score = 0;
        gameManager.UpdateLife(life);
    }
    private void Update()
    {
        Inputs();
        Move();
        Fire();
        fuel -= Time.deltaTime * 3;
        fuelImage.fillAmount = (float)fuel / 100f;
        if(fuel < 0f)
        {
            life = 0;
            gameManager.UpdateLife(life);
            gameObject.SetActive(false);
        }
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
    IEnumerator Return()
    {
        yield return new WaitForSeconds(3f);
        canDamage = true;
        transform.GetChild(0).gameObject.SetActive(false);
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
        else if(collision.gameObject.tag == "EnemyBullet")
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
        else if(collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.iT)
            {
                case Item.ItemType.fix:
                    score += 100;
                    life++;
                    if(life > 3)
                    {
                        life = 3;
                        
                    }
                    gameManager.UpdateLife(life);
                    Destroy(collision.gameObject);
                    break;
                case Item.ItemType.fuel:
                    score += 100;
                    fuel += 40f;
                    if (fuel > 100f)
                    {
                        fuel = 100f;
                    }
                    Destroy(collision.gameObject);
                    break;
                case Item.ItemType.upgrade:
                    score += 100;
                    BulletLvl++;
                    if (BulletLvl > 3) BulletLvl = 3;
                    Destroy(collision.gameObject);
                    break;
                case Item.ItemType.coin:
                    score += 1000;
                    Destroy(collision.gameObject);
                    break;
                case Item.ItemType.barrior:
                    
                    score += 100;
                    transform.GetChild(0).gameObject.SetActive(true);
                    canDamage = false;
                    Destroy(collision.gameObject);
                    StopCoroutine(Return());
                    StartCoroutine(Return());
                    break;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (!canDamage) return;
            Destroy(collision.gameObject);
            
            life--;
            if (life == 0)
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
