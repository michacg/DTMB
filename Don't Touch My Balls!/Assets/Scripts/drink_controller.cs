using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink_controller : MonoBehaviour
{
    private float drinking_speed = 1;
    public GameObject instrPanel;

    private float cup_size = 10;
    private Vector2 top;

    private bool drinking;

    void Start()
    {
        LevelManager.instance.timeRemaining = LevelManager.instance.startTime; 

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        cup_size = sr.bounds.size.y;
        top = FindTopVector();

        drinking = false;
    }

    void Update()
    {
        if (instrPanel.activeSelf == false)
            LevelManager.instance.timeRemaining -= Time.deltaTime;

        LevelManager.instance.vacuuming = drinking;

        if (drinking)
        {
            RemoveDrink();
        }
        else
        {
            StopDrink();
        }

        if (LevelManager.instance.timeRemaining <= 0)
        {
            LevelManager.instance.isGameOver = true;
            LevelManager.instance.hasWon = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            drinking =  true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            drinking = false;
        }   
    }

    private float CalculateDrinkSpeed()
    {
        return (cup_size / LevelManager.instance.startTime) * Time.deltaTime * 2.5f; //hardcoded
    }

    private void RemoveDrink()
    {        
        gameObject.transform.Translate(Vector2.down * CalculateDrinkSpeed());
    }

    private void StopDrink()
    {
        gameObject.transform.Translate(Vector2.down * 0);
    }

    private Vector2 FindTopVector()
    {
        return new Vector2(transform.position.x, transform.position.y + (cup_size / 2));
    }
}
