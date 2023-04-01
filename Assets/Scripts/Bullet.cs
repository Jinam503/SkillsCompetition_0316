using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { Player_1, Player_2, Player_3 }
    public BulletType bt;

    private int damage;

    private void Start()
    {
        switch (bt)
        {
            case BulletType.Player_1:
                damage = 1;
                break;
            case BulletType.Player_2:
                damage = 3;
                break;
            case BulletType.Player_3:
                damage = 10;
                break;
        }
    }
    private void Update()
    {
        switch (bt)
        {
            case BulletType.Player_1:
                transform.Translate(Vector2.right * 20f * Time.deltaTime);
                break;
            case BulletType.Player_2:
                transform.Translate(Vector2.right * 20f * Time.deltaTime);
                break;
            case BulletType.Player_3:
                transform.Translate(Vector2.right * 20f * Time.deltaTime);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DestroyWall":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.gameObject.GetComponent<Enemy>().OnHit(damage);
                Destroy(gameObject);
                break;
            case "Barrior":
                collision.gameObject.GetComponent<Barrior>().OnHit(damage);
                Destroy(gameObject);
                break;
            default:
                break;
        }
        
    }
}
