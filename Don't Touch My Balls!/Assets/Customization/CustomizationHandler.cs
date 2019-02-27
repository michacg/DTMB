using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CustomizationHandler : MonoBehaviour
{
    public Transform playButton;
    
    public TextMeshProUGUI buttonText;

    private bool flavorSelected = false;

    void Awake()
    {
        playButton.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if (flavorSelected)
        {
            FillCup();
            playButton.GetComponent<Button>().interactable = true;
        }
        else
            playButton.GetComponent<Button>().interactable = false;
    }

    public void LoadTea(string color)
    {
        color = color.ToLower();

        if (buttonText != null)
            buttonText.color = Color.black;

        if (color.Equals("milk"))
            LevelManager.instance.teaFlavor = new Color(0.8078431f, 0.6941177f, 0.5843138f);
        else if (color.Equals("matcha"))
            LevelManager.instance.teaFlavor = new Color(0.6226543f, 0.8962264f, 0.5707102f);
        else if (color.Equals("thai"))
            LevelManager.instance.teaFlavor = new Color(1f, 0.5450981f, 0.2980392f);
        else if (color.Equals("taro"))
            LevelManager.instance.teaFlavor = new Color(0.6509804f, 0.5882353f, 0.7254902f);

        flavorSelected = true;
        LevelManager.instance.drink.transform.position = new Vector2(0, -5);

        buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void FillCup()
    {
        if (LevelManager.instance.drink.transform.position.y <= -0.75f)
            LevelManager.instance.drink.transform.Translate(Vector2.up * Time.deltaTime * 4f);
    }
}
