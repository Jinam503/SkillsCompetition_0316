using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public enum EnemyType { FastSmall };
    public EnemyType eT;
    public float speed;

    Rigidbody2D rigid;

    protected virtual void Awake()
    {
        switch (eT)
        {
            case EnemyType.FastSmall:
                rigid = GetComponent<Rigidbody2D>();
                GameObject player = GameObject.Find("Player"); // �÷��̾� ������Ʈ�� ã���ϴ�.
                Vector2 direction = player.transform.position - transform.position; // �� ������ �÷��̾� ������ ������ ����մϴ�.
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // �� ������ �÷��̾� ������ ������ ����մϴ�.
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                rigid.velocity = transform.up * speed;
                hp = 1;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            GetDamage(bullet.damage);
            Destroy(collision.gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
