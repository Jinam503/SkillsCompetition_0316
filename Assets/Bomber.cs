using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    private void Update()
    {
        if(hp > 0)
        {
            transform.Translate(Vector2.up * 3f * Time.deltaTime);
        }
    }
    public override void OnHit(int damage)
    {
        hp -= damage;
        if(hp < 0)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        
    }
}
