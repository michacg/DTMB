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
    public float timer = 60;
    private float time_remaining = 60;
    private float drinking_speed = 1;
    // private float unaccounted_time = 0;
    
    private float cup_size = 10;
    private Vector2 top;

    private bool drinking;

    // Start is called before the first frame update
    void Start()
    {
        time_remaining = timer; 

        // Get the height of the drink
        // NOTE: this is assuming that the drink is correctly scaled to 
        // touching the bottom of the cup.
        // float cup_size = gameObject.transform.lossyScale.y;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        cup_size = sr.bounds.size.y;
        top = FindTopVector();

        drinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        time_remaining -= Time.deltaTime;
        Debug.Log(time_remaining);

        if (drinking)
        {
            RemoveDrink();
        }

        if (time_remaining <= 0)
        {
            Debug.Log("Game Over time boi");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        drinking = true;
        
        // drinking_speed = (cup_size - Vector2.Distance(top, transform.position)) / time_remaining; // speed based on per unit
        // drinking_speed = drinking_speed / 10; // speed based on per pixel
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        drinking = false;
        drinking_speed = 0;
    }

    private float CalculateDrinkSpeed()
    {
        return (cup_size / timer) * Time.deltaTime;
    }

    private void RemoveDrink()
    {
        // gameObject.transform.Translate(Vector2.down * CalculateDrinkSpeed());
        
        drinking_speed = (cup_size - Vector2.Distance(top, FindTopVector())) / time_remaining;
       
        gameObject.transform.Translate(Vector2.down * drinking_speed * Time.deltaTime);
    }

    private Vector2 FindTopVector()
    {
        return new Vector2(transform.position.x, transform.position.y + (cup_size / 2));
    }
}
