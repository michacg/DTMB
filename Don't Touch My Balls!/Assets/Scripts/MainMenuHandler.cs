using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject creditsPanel;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void ExitCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
