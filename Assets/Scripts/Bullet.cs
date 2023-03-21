using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { Player , EnemyA};
    public BulletType bt;
    public int damage;
    private void Awake()
    {
        switch (bt)
        {
            case BulletType.Player:
                damage = 1;
                break;
            case BulletType.EnemyA:
                damage = 2;
                break;
        }
    }
    private void Update()
    {
        switch (bt)
        {
            case BulletType.Player:
                transform.Translate(Vector2.up * 12 * Time.deltaTime);
                break;
            case BulletType.EnemyA:
                transform.Translate(Vector2.up * 5 * Time.deltaTime);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BulletWall")
        {
            Destroy(gameObject);
        }
    }
}
