using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winnerPanel;
    public GameObject loserPanel;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LevelManager.instance.isGameOver = true;
            LevelManager.instance.hasWon = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
            LevelManager.instance.isGameOver = true;

        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

        if (LevelManager.instance.isGameOver)
        {
            if (LevelManager.instance.hasWon)
            {
                winnerPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                FindObjectOfType<AudioManager>().StopImmediate("Opening");
                loserPanel.SetActive(true);
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
        LevelManager.instance.isGameOver = false;
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
