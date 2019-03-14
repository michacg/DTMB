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
    public Transform smallButton;
    public Transform regButton;

    public TextMeshProUGUI buttonText;

    public GameObject spriteObject;
    private RectTransform sprite;
    public GameObject RegularCup;
    public GameObject SmallCup;

    private bool flavorSelected = false;
    private int yLeft = 0;

    void Awake()
    {
        playButton.GetComponent<Button>().interactable = false;
        regButton.GetComponent<Button>().interactable = false;
        smallButton.GetComponent<Button>().interactable = true;
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
        {
            playButton.GetComponent<Button>().interactable = false;
        }

        if (LevelManager.instance.isSmallMode)
        {
            regButton.GetComponent<Button>().interactable = true;
            smallButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            regButton.GetComponent<Button>().interactable = false;
            smallButton.GetComponent<Button>().interactable = true;
        }

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
        if (LevelManager.instance.isSmallMode)
            LevelManager.instance.drink.transform.position = new Vector2(0.17f, -5.5f);
        else
            LevelManager.instance.drink.transform.position = new Vector2(0, -4.75f);

        buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadPlayScene()
    {
        if (LevelManager.instance.isSmallMode)
        {
            SceneManager.LoadScene("DrinkTimer - (Mich) 1");
        }
        else
        {
            SceneManager.LoadScene("DrinkTimer - (Mich)");
        }
    }

    public void FillCup()
    {
        if (LevelManager.instance.isSmallMode)
        {
            if (LevelManager.instance.drink.transform.position.y <= -1f)
                LevelManager.instance.drink.transform.Translate(Vector2.up * Time.deltaTime * 3f);
        }
        else
        {
            if (LevelManager.instance.drink.transform.position.y <= -0.75f)
                LevelManager.instance.drink.transform.Translate(Vector2.up * Time.deltaTime * 4f);
        }
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

    public void ChangeMode(string mode)
    {
        mode = mode.ToLower();

        if (buttonText != null)
            buttonText.color = Color.black;


        if (mode.Equals("regular"))
        {
            SmallCup.SetActive(false);
            RegularCup.SetActive(true);

            LevelManager.instance.isSmallMode = false;

            LevelManager.instance.drink.transform.position = new Vector2(0, -6f);
            LevelManager.instance.drink.transform.localScale = new Vector3(1.0f, 0.77f, 1.0f);

            LevelManager.instance.bobaQuantity = 20;

            LevelManager.instance.isSmallMode = false;
        }
        else if (mode.Equals("small"))
        {
            RegularCup.SetActive(false);
            SmallCup.SetActive(true);

            LevelManager.instance.isSmallMode = true;

            LevelManager.instance.drink.transform.position = new Vector2(0.17f, -5.5f);
            LevelManager.instance.drink.transform.localScale = new Vector3(0.775f, 0.51f, 1.0f);

            LevelManager.instance.bobaQuantity = 15;

            LevelManager.instance.isSmallMode = true;
        }

        buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }
}
