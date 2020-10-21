using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;

    public Text scoreText;
    public Text lostApples;

    private bool restartGame = false;
    private int applesDecrement = 100;

    private bool gameOverCalledThisFrame;

    void Start()
    {
        gameOver = GameObject.Find("Canvas")
        .transform.Find("Game Over Panel").gameObject;

        scoreText = GameObject.Find("Canvas")
        .transform.Find("Score").GetComponent<Text>();
        
        lostApples = GameObject.Find("Canvas")
        .transform.Find("Game Over Panel")
        .transform.Find("Lost Apples").GetComponent<Text>();

        // Boolean to prevent multiple calls to showGameOver function
        gameOverCalledThisFrame = false;

        // Take the total score value when the scene changes
        UpdateScoreText();

        // To be able to access this class in other scripts
        instance = this;

        // To find out how many apples the player picked up before the level
        StaticVariables.AmountApplesLevelPast = StaticVariables.TotalScore;
    }

    public void UpdateScoreText()
    {
        scoreText.text = StaticVariables.TotalScore.ToString().PadLeft(4, '0');
    }
    
    public void ShowGameOver()
    {
        // Preventing multiple calls
        if (gameOverCalledThisFrame) return;
        gameOverCalledThisFrame = true;

        gameOver.SetActive(true);

        // Showing the lost apples on the game over screen
        if (StaticVariables.TotalScore - applesDecrement >= 0)
        {
            lostApples.text = "-" + Convert.ToString(applesDecrement).PadLeft(4, '0');
        }
        else
        {
            lostApples.text = "-" + Convert.ToString(StaticVariables.TotalScore).PadLeft(4, '0');
        }

        // Take (applesDecrement) apples when losing
        if (StaticVariables.TotalScore - applesDecrement >= 0)
        {
            StaticVariables.TotalScore -= applesDecrement;
        }
        
        // If you die and have no (applesDecrement) to lose, player returns to the beginning of the game
        else
        {
            restartGame = true;
        }

    }

    public void Restart()
    {
        // Restart level
        if (!restartGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Restart game
        else
        {
            ResetTotalScore();
            SceneManager.LoadScene(3);
        }

    }

    public void ResetTotalScore()
    {
        StaticVariables.AmountApplesLevelPast = 0;
        StaticVariables.TotalScore = 0;
    }

}
