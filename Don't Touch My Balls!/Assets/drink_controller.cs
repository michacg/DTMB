using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink_controller : MonoBehaviour
{
    public float timer = 60;
    private float time_remaining = 60;
    private float cup_size = 10;

    // Start is called before the first frame update
    void Start()
    {
        time_remaining = timer; 

        // Get the height of the drink
        // Note: this is assuming that the drink is correctly scaled to 
        // touching the bottom of the cup.
        // float cup_size = gameObject.transform.lossyScale.y;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        cup_size = sr.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        time_remaining -= Time.deltaTime;
        RemoveDrink();

        if (time_remaining <= 0)
        {
            Debug.Log("Game Over time boi");
        }
    }

    private float CalculateDrinkSpeed()
    {
        return (cup_size / timer) * Time.deltaTime;
    }

    private void RemoveDrink()
    {
        gameObject.transform.Translate(Vector2.down * CalculateDrinkSpeed());
    }
}
