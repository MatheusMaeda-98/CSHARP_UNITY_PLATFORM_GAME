using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour

{       
    public int totalScore;
    public static GameController instance;

    public GameObject gameOver;

    public Text scoreText;

    void Start()
    {   

         instance = this;

        // Reseta o score apenas se for a cena inicial
        if (SceneManager.GetActiveScene().buildIndex == 0) // Supondo que a cena inicial seja o índice 0
        {
            PlayerPrefs.SetInt("TotalScore", 0);
            totalScore = 0;
        }
        else if (PlayerPrefs.HasKey("TotalScore"))
        {
            totalScore = PlayerPrefs.GetInt("TotalScore");
        }

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);   
    }
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    
}