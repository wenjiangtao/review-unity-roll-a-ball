using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{

    public Text winText;
    public Text scoreText;
    
    void Start()
    {
        PlayerController.OnGetScore += OnGetScore;
        PlayerController.OnWin += OnWin;
    }
    
    void OnGetScore(int score)
    {
        Debug.Log(score);
        scoreText.text = "Score: " + score;
    }
    
    void OnWin()
    {
        winText.gameObject.SetActive(true);
    }
}
