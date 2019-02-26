﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomizationHandler : MonoBehaviour
{
    public GameObject drink;
    public Transform button;

    public Button milkButton;
    public Button matchaButton;
    public Button thaiButton;
    public Button taroButton;

    private TextMeshProUGUI buttonText;
    private SpriteRenderer drinkSprite;

    private bool flavorSelected = false;

    void Awake()
    {
        button.GetComponent<Button>().interactable = false;
        drinkSprite = drink.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (flavorSelected)
        {
            FillCup();
            button.GetComponent<Button>().interactable = true;
        }
        else
            button.GetComponent<Button>().interactable = false;
    }

    public void LoadMilkTea()
    {
        if (buttonText != null)
            buttonText.color = Color.black;

        drinkSprite.color = new Color(0.8078431f, 0.6941177f, 0.5843138f);
        flavorSelected = true;
        drink.transform.position = new Vector2(0, -5);

        buttonText = milkButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadMatchaTea()
    {
        if (buttonText != null)
            buttonText.color = Color.black;

        drinkSprite.color = new Color(0.6226543f, 0.8962264f, 0.5707102f);
        flavorSelected = true;
        drink.transform.position = new Vector2(0, -5);

        buttonText = matchaButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadThaiTea()
    {
        if (buttonText != null)
            buttonText.color = Color.black;

        drinkSprite.color = new Color(1f, 0.5450981f, 0.2980392f);
        flavorSelected = true;
        drink.transform.position = new Vector2(0, -5);

        buttonText = thaiButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadTaroTea()
    {
        if (buttonText != null)
            buttonText.color = Color.black;
        drink.transform.position = new Vector2(0, -5);

        drinkSprite.color = new Color(0.6509804f, 0.5882353f, 0.7254902f);
        flavorSelected = true;

        buttonText = taroButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = Color.white;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void FillCup()
    {
        if (drink.transform.position.y <= -0.75f)
            drink.transform.Translate(Vector2.up * Time.deltaTime * 4f);
    }
}