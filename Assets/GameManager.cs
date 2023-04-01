using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Image[] lifeImages;
    public GameObject GameOver;
    public Text scoreText;
    public Player player;

    private void Start()
    {
        
        score = 0;
        scoreText.text = string.Format("{0:n0}", score);
    }
    public void GetScore(int score)
    {
        this.score += score;
        scoreText.text = string.Format("{0:n0}", score);
    }
    public void UpdateLife(int life)
    {
        if(life == 0)
        {
            GameOver.gameObject.SetActive(true);
        }
        for(int i = 0; i < 3; i++)
        {
            lifeImages[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < life; i++)
        {
            lifeImages[i].color = new Color(1, 1, 1, 1);
        }
    }
    public void Retry()
    {
        GameOver.SetActive(false);
        player.gameObject.SetActive(true);
        player.life = 3;
        UpdateLife(3);
        player.transform.position = new Vector3(0, -3, 0);
    }
}
