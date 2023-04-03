using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickStage : MonoBehaviour
{
    public GameObject Back;
    public void ClickStage()
    {
        Back.SetActive(true);
        
    }
    public void ClickBack()
    {
        Back.SetActive(false);
    }
    public void ClickGo1()
    {
        SceneManager.LoadScene("Stage 1");
    }
    public void ClickGo2()
    {
        SceneManager.LoadScene("Stage 2");
    }
}
