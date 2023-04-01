using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float h;
    private float v;
    public float moveSpeed;

    public GameObject playerBullet_1;
    public GameObject playerBullet_2;
    public GameObject playerBullet_3;

    public float maxShootDelay;
    public float curShootDelay = 0f;

    private bool touchL;
    private bool touchR;
    private bool touchT;
    private bool touchB;

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
        Instantiate(playerBullet_1, transform.position, rot);
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
