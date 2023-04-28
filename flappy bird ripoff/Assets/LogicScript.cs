using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore;
    public Text scoreText;

    public GameObject gameOverPanel;

    [ContextMenu("Add Score")]
    public void AddScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        scoreText.text = PlayerScore.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
