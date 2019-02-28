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

    public GameObject spriteObject;
    private RectTransform sprite;

    private bool flavorSelected = false;
    private int yLeft = 0;

    void Awake()
    {
        playButton.GetComponent<Button>().interactable = false;
        sprite = spriteObject.GetComponent<RectTransform>();
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

        if (yLeft != 0)
        {
            MoveSprite();
        }
    }

    public void LoadTea(string color)
    {
        color = color.ToLower();

        if (buttonText != null)
            buttonText.color = Color.black;

        if (color.Equals("milk"))
        {
            LevelManager.instance.teaFlavor = new Color(0.8078431f, 0.6941177f, 0.5843138f);
            yLeft = 15;
        }
        else if (color.Equals("matcha"))
        {
            LevelManager.instance.teaFlavor = new Color(0.6226543f, 0.8962264f, 0.5707102f);
            yLeft = -35;
        }
        else if (color.Equals("thai"))
        {
            LevelManager.instance.teaFlavor = new Color(1f, 0.5450981f, 0.2980392f);
            yLeft = -85;
        }
        else if (color.Equals("taro"))
        {
            LevelManager.instance.teaFlavor = new Color(0.6509804f, 0.5882353f, 0.7254902f);
            yLeft = -135;
        }

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

    public void MoveSprite()
    {
        Vector2 position = sprite.anchoredPosition;

        if (position.y > yLeft)
            sprite.anchoredPosition = sprite.anchoredPosition + new Vector2(0, -10);
        else if (position.y < yLeft)
            sprite.anchoredPosition = sprite.anchoredPosition + new Vector2(0, 10);

        if (!spriteObject.activeSelf && position.y != 0)
        {
            sprite.anchoredPosition = new Vector2(-167.5f, yLeft);
            spriteObject.SetActive(true);
        }
    }
}
