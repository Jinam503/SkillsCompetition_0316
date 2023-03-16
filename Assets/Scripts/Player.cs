using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int bulletLvl;

    public GameObject bulletPrefab;

    private bool isTrigger_L;
    private bool isTrigger_R;
    private bool isTrigger_T;
    private bool isTrigger_B;

    private float curD;
    private float maxD = 0.1f;

    private void Update()
    {
        Move();
        Fire();
        R();
    }

    private void Fire()
    {
        if (curD < maxD) return;
        switch (bulletLvl)
        {
            case 1:
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                break;
            case 2:
                break;
        }
        curD = 0f;
    }
    private void R()
    {
        curD += Time.deltaTime;
    }
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        if ((isTrigger_T && v == 1) || (isTrigger_B && v == -1)) v = 0;
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTrigger_R && h == 1) || (isTrigger_L && h == -1)) h = 0;
        Vector2 curPos = transform.position;
        Vector2 nextPos = new Vector2(h, v) * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerWall")
        {
            switch (collision.gameObject.name)
            {
                case "L":
                    isTrigger_L = true;
                    break;
                case "R":
                    isTrigger_R = true;
                    break;
                case "T":
                    isTrigger_T = true;
                    break;
                case "B":
                    isTrigger_B = true;
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWall")
        {
            switch (collision.name)
            {
                case "L":
                    isTrigger_L = false;
                    break;
                case "R":
                    isTrigger_R = false;
                    break;
                case "T":
                    isTrigger_T = false;
                    break;
                case "B":
                    isTrigger_B = false;
                    break;
            }
        }
    }
}
