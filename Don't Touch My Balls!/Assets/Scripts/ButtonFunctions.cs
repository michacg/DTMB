using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winnerPanel;
    public GameObject loserPanel;
    public GameObject audioManager;

    private bool isPaused = false;
    private bool gameEnded = false;   //bool for audio stuff to make sure song doesnt repeatedly start in the update

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager");
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
                if(gameEnded == false)
                {
                    FindObjectOfType<AudioManager>().Victory();
                    gameEnded = true;
                }
                pausePanel.SetActive(false);
                winnerPanel.SetActive(true);
                LevelManager.instance.FreezeGame();
            }
            else
            {
                if(gameEnded == false)
                {
                    FindObjectOfType<AudioManager>().GameOverMusic();
                    gameEnded = true;
                }
                pausePanel.SetActive(false);
                loserPanel.SetActive(true);
                LevelManager.instance.FreezeGame();
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
        gameEnded = false;
        Destroy(audioManager);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        Destroy(audioManager);
        SceneManager.LoadScene("MainScene");
        LevelManager.instance.isGameOver = false;
        LevelManager.instance.hasWon = false;
        LevelManager.instance.teaFlavor = new Color();
    }
}
