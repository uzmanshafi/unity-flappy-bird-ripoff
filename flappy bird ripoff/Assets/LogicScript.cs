using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public pipe_spawner pipeSpawner;
    public int PlayerScore;
    public Text scoreText;
    public GameObject gameOverPanel;
    public Text timerText;
    private float startTime;
    private bool gameIsOver = false;

    public Text highScoreText;
    private int highScore;

    [ContextMenu("Add Score")]
    public void AddScore(int ScoreToAdd)
    {
        if (!gameIsOver)
        {
            PlayerScore += ScoreToAdd;
            scoreText.text = PlayerScore.ToString();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameIsOver = true;
        
        gameOverPanel.SetActive(true);

        pipeSpawner.enabled = false;
        foreach (move_speed_pipe pipe in FindObjectsOfType<move_speed_pipe>())
        {
            pipe.GetComponent<move_speed_pipe>().gameIsOver = true;
        }

        if (PlayerScore > highScore)
        {
            highScore = PlayerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
        }
    }

    void Start()
    {
        startTime = Time.time;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (!gameIsOver)
        {
            // Update the timer
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = string.Format("{0}:{1}", minutes, seconds);
        } else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetGame();
            }
        }

        scoreText.text = PlayerScore.ToString();
        highScoreText.text = highScore.ToString();
    }
}
