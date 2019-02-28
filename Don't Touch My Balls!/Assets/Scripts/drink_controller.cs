using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* TODO:
 * 1. Make the timer of the drink independent of the straw's
 *    interval. (Partial, see BUGS).
*/

/* KNOWN BUGS:
 * 1. When the straw is out of the drink, but the overall game
 *    timer reaches 0, the drink might not have reached the 
 *    red line yet.
 */

public class drink_controller : MonoBehaviour
{
    private float drinking_speed = 1;
    // private float unaccounted_time = 0;
    
    private float cup_size = 10;
    private Vector2 top;

    private bool drinking;

    void Start()
    {
        LevelManager.instance.timeRemaining = LevelManager.instance.startTime; 

        // Get the height of the drink
        // NOTE: this is assuming that the drink is correctly scaled to 
        // touching the bottom of the cup.
        // float cup_size = gameObject.transform.lossyScale.y;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        cup_size = sr.bounds.size.y;
        top = FindTopVector();

        drinking = false;
    }

    void Update()
    {
        LevelManager.instance.timeRemaining -= Time.deltaTime;
        //Debug.Log(LevelManager.instance.timeRemaining);

        if (drinking)
        {
            RemoveDrink();
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
        else
        {
            drinking = false;
            drinking_speed = 0;
        }

        // drinking_speed = (cup_size - Vector2.Distance(top, transform.position)) / time_remaining; // speed based on per unit
        // drinking_speed = drinking_speed / 10; // speed based on per pixel
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // drinking = false;
        // drinking_speed = 0;
    }

    private float CalculateDrinkSpeed()
    {
        // Debug.Log(cup_size + ", " + LevelManager.instance.startTime);

        return (cup_size / LevelManager.instance.startTime) * Time.deltaTime * 5; //hardcoded
    }

    private void RemoveDrink()
    {
        //gameObject.transform.Translate(Vector2.down * CalculateDrinkSpeed());
        
        //drinking_speed = (cup_size - Vector2.Distance(top, FindTopVector())) / LevelManager.instance.timeRemaining;
        
        gameObject.transform.Translate(Vector2.down * CalculateDrinkSpeed());
    }

    private Vector2 FindTopVector()
    {
        return new Vector2(transform.position.x, transform.position.y + (cup_size / 2));
    }
}
