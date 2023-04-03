using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchToStart : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(PadeIn());
    }
    IEnumerator PadeIn()
    {
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            text.color = new Color(1f, 1f, 1f, i);
        }
        for (float i = 0; i<= 1; i += 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            text.color = new Color(1f,1f,1f,i);
        }
        StartCoroutine(PadeIn());
    }
}
