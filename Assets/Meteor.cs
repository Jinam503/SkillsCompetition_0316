using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Rigidbody2D r;
    public GameObject player;
    private bool follow;
    public int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        follow = true;
        r = GetComponent<Rigidbody2D>();
        r.gravityScale = 0;
        StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3f);
        r.gravityScale = 0.7f;
        follow = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void Update()
    {
        if (follow)
        {
            Vector3 n = Vector3.zero;

            if (transform.position.x > player.transform.position.x)
            {
                n = Vector3.left * 0.005f;
            }
            else if (transform.position.x < player.transform.position.x)
            {
                n = Vector3.right * 0.005f;
            }
            transform.position = transform.position + n;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DestroyWall")
        {
            Destroy(gameObject);
        }
        else if( collision.gameObject.tag == "PlayerBullet")
        {
            hp--;
            player.GetComponent<Player>().score += 500;
            player.GetComponent<Player>().BreakMeteor();
            if (hp <= 0) Destroy(gameObject);
        }
    }
}
