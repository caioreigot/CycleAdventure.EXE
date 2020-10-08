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

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("Canvas")
        .transform.Find("Game Over Panel").gameObject;

        scoreText = GameObject.Find("Canvas")
        .transform.Find("Score").GetComponent<Text>();
        
        lostApples = GameObject.Find("Canvas")
        .transform.Find("Game Over Panel")
        .transform.Find("Lost Apples").GetComponent<Text>();

        // Pegar o valor do total score quando mudar de cena
        UpdateScoreText(); 

        // Reseta a pontuação obtida na cena
        ResetEarnedSceneScore();

        // Para poder acessar essa classe em outros scripts
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = StaticVariables.TotalScore.ToString().PadLeft(4, '0');
    }
    
    public void ShowGameOver()
    {
        gameOver.SetActive(true);

        // Mostrando as maças perdidas na tela de Game Over
        if (StaticVariables.TotalScore - applesDecrement >= 0)
        {
            lostApples.text = "-" + Convert.ToString(applesDecrement).PadLeft(4, '0');
        }
        else
        {
            lostApples.text = "-" + Convert.ToString(StaticVariables.TotalScore).PadLeft(4, '0');
        }

        // Tirar (applesDecrement) maças ao perder
        if (StaticVariables.TotalScore - applesDecrement >= 0)
        {
            StaticVariables.TotalScore -= applesDecrement;
        }
        // Se morrer e não tiver (applesDecrement) maças para perder, o jogador volta ao inicio do jogo.
        else
        {
            restartGame = true;
        }
    }

    public void Restart()
    {
        // Reiniciar level
        if (!restartGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Reiniciar jogo
        else
        {
            ResetTotalScore();
            SceneManager.LoadScene(0);
        }

    }

    #region Funções de RESET
    public void ResetEarnedSceneScore()
    {
        Apple.sceneScoreEarned = 0;
    }

    public void ResetTotalScore()
    {
        StaticVariables.TotalScore = 0;
    }
    #endregion

}
