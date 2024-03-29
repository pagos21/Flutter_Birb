using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FlutterUnityIntegration;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreTxt;
    public GameObject gameOverScreen;
    public UnityMessageManager mess;
    public bool isGameOver = false;
    private bool isMessSent = false;

    [ContextMenu("Increase score")]
    public void addScore(int score2Add)
    {
        playerScore += score2Add;
        scoreTxt.text = playerScore.ToString();
    }

    public void resetGame()
    {
        isGameOver = false;
        isMessSent = false;
        scoreTxt.text = "0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        if (!isMessSent)
        {
            mess.SendMessageToFlutter(scoreTxt.text);
            isMessSent = true;
        }
    }
}
