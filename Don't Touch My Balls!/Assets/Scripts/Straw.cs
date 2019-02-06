using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* KNOWN BUGS:
 *  1. Straw timer does not work properly right now. It
 *     waits for the 5 seconds interval only on the first
 *     time. Then it seems to go down in much shorter 
 *     time than 5 seconds.
 *  2. There are some instances where the bottom of the 
 *     straw doe snot line up with the top of the drink and
 *     the drink has already starts decreasing. And vice
 *     versa.
*/

public class Straw : MonoBehaviour
{
	public GameObject leftBound;
	public GameObject rightBound;
	public GameObject upperBound;
    public GameObject drinkBound;

	public float interval;

	private float left_x;
	private float right_x;
	private float lower_y;
	private float upper_y;

    private float drink_y;

	private float timeElapsed;
    private float speed;
    private float rand_time;

	private Vector2 fallDirection;
    private Vector2 sideDirection;

    private drink_controller drinkController;

    // Start is called before the first frame update
    void Start()
    {
    	left_x = leftBound.transform.position.x;
    	right_x = rightBound.transform.position.x;
    	lower_y = leftBound.transform.position.y;
    	upper_y = upperBound.transform.position.y;

        drink_y = drinkBound.transform.position.y;
        
    	fallDirection = new Vector2(0, 0);
        sideDirection = Vector2.right;
    	timeElapsed = 0;
        transform.position = new Vector2(transform.position.x, upper_y);

        drinkController = GameObject.Find("drink").GetComponent<drink_controller>();
    }

    // Update is called once per frame
    void Update()
    {
    	//this.transform.position =  new Vector2(Random.Range(left_x, right_x), this.transform.position.y);

    	timeElapsed += Time.deltaTime;

        // straw is below the cup
    	if (this.transform.position.y <= lower_y)
    	{
            if (fallDirection != Vector2.up)
            {
                fallDirection = Vector2.up;
                rand_time = Random.Range(1, interval - timeElapsed);
                speed = (upper_y - lower_y) / rand_time;
            }

        }
        // straw is completely out of the cup
    	else if (this.transform.position.y >= upper_y)
    	{
    		if (timeElapsed >= interval)
    		{
                MoveSide();
                if (fallDirection != Vector2.down)
                {   
                    fallDirection = Vector2.down;
    			    timeElapsed = 0;

                    rand_time = Random.Range(0.05f, 1);
                    speed = (upper_y - lower_y) / rand_time;
                }
            }

    		else
    		{
                MoveSide();
    			fallDirection = new Vector2(0, 0);
    		}
    	}
        // straw is below the drink line
        else if (transform.position.y <= drink_y)
        {
            // Make the drink start decreasing
            drinkController.IsDrinking(true);
        }
        // straw is above the drink line
        else if (transform.position.y > drink_y)
        {
            // Make the drink stop decreasing
            drinkController.IsDrinking(false);
        }

    	MoveDown();
    }

    void MoveDown()
    {
        this.transform.Translate(fallDirection * speed * Time.deltaTime);
        
        /*
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        // GetComponent<Rigidbody2D>().AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        Debug.Log("second line " + GetComponent<Rigidbody2D>().velocity);
        */
    }

    void MoveSide()
    {
        rand_time = Random.Range(0.05f,2);
        speed     = (right_x - left_x) / rand_time;

        if (this.transform.position.x >= right_x)
        {
            sideDirection = Vector2.left;
        }

        if (this.transform.position.x <= left_x)
        {
            sideDirection = Vector2.right;
        }

        this.transform.Translate(sideDirection * speed * Time.deltaTime);
    }
}
