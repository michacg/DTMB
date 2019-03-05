﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
    public bool isGameOver;
    public bool hasWon;
    public float startTime = 90f;
	public float timeRemaining;

    public Color teaFlavor;
    public GameObject drink;
    public SpriteRenderer drinkSprite;

    private bool flavorSelected = false;

    public int bobaQuantity = 20;

    void Awake()
    {
        //depending on drink size, will change timer and amount of boba etc.
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(instance);

        timeRemaining = startTime;
        isGameOver    = false;
        hasWon        = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTeaColor();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = true;
            hasWon = true;
        }
    }

    void SetTeaColor()
    {
        if (drink == null)
            drink = GameObject.FindWithTag("Drink");
        else
        {
            drinkSprite = drink.GetComponent<SpriteRenderer>();
            if (drinkSprite.color != teaFlavor)
                drinkSprite.color = teaFlavor;
        }
    }
}
