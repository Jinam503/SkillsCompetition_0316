using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { Player_1, Player_2, Player_3, Enemy_1, Enemy_2, Enemy_3 }
    public BulletType bt;

    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DestroyWall":
                Destroy(gameObject);
                break;
        }
        
    }
}
