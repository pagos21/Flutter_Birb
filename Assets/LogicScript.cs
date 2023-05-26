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

    [ContextMenu("Increase score")]
    public void addScore(int score2Add)
    {
        playerScore += score2Add;
        scoreTxt.text = playerScore.ToString();
    }

    public void resetGame()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        mess.SendMessageToFlutter(scoreTxt.text);
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }
}
