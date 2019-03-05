using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayHandler : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winnerPanel;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (LevelManager.instance.isGameOver)
        {
            if (LevelManager.instance.hasWon)
            {
                winnerPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
        LevelManager.instance.isGameOver = false;
        LevelManager.instance.hasWon = false;
        LevelManager.instance.teaFlavor = new Color();
    }
}
