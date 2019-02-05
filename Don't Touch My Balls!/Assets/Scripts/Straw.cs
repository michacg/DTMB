using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : MonoBehaviour
{
	public GameObject leftBound;
	public GameObject rightBound;
	public GameObject upperBound;

	public float interval;

	private float left_x;
	private float right_x;
	private float lower_y;
	private float upper_y;

	private float timeElapsed;
    private float speed;

	private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    	left_x = leftBound.transform.position.x;
    	right_x = rightBound.transform.position.x;
    	lower_y = leftBound.transform.position.y;
    	upper_y = upperBound.transform.position.y;
        
    	direction = new Vector2(0, 0);
    	timeElapsed = 0;
        transform.position = new Vector2(transform.position.x, upper_y);
    }

    // Update is called once per frame
    void Update()
    {
    	//this.transform.position =  new Vector2(Random.Range(left_x, right_x), this.transform.position.y);

    	timeElapsed += Time.deltaTime;

    	if (this.transform.position.y <= lower_y)
    	{
            if (direction != Vector2.up)
            {
                direction = Vector2.up;
                float rand_time = Random.Range(1, interval - timeElapsed);
                speed = (upper_y - lower_y) / rand_time;
            }
        }

    	else if (this.transform.position.y >= upper_y)
    	{
    		if (timeElapsed >= interval)
    		{
                if (direction != Vector2.down)
                {
                    direction = Vector2.down;
    			    timeElapsed = 0;

                    float rand_time = Random.Range(0.05f, 1);
                    speed = (upper_y - lower_y) / rand_time;
                }
            }
    		else
    		{
    			direction = new Vector2(0, 0);
    		}
    	}

    	Move();
    }

    void Move()
    {
        this.transform.Translate(direction * speed * Time.deltaTime);
        
        /*
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        // GetComponent<Rigidbody2D>().AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        Debug.Log("second line " + GetComponent<Rigidbody2D>().velocity);
        */
    }
}
