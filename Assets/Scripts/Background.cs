using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private void Update()
    {
        Vector3 nextPos = Vector3.down * 1.5f * Time.deltaTime;
        transform.position = transform.position + nextPos;
        if(transform.position.y < -11)
        {
            Vector3 pos = transform.position + (Vector3.up * 24);
            transform.position = pos;
        }
    }
}
