using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreTxt;
    public GameObject gameOverScreen;

    [ContextMenu("Increase score")]
    public void addScore(int score2Add)
    {
        playerScore += score2Add;
        scoreTxt.text = playerScore.ToString();
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
