using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : MonoBehaviour
{
	public GameObject leftBound;
	public GameObject rightBound;
	public GameObject upperBound;

	public float speed;
	public float interval;

	private float left_x;
	private float right_x;
	private float lower_y;
	private float upper_y;
	private float timeElapsed;

	private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    	left_x = leftBound.transform.position.x;
    	right_x = rightBound.transform.position.x;
    	lower_y = leftBound.transform.position.y;
    	upper_y = upperBound.transform.position.y;

    	Debug.Log(left_x + "; " + right_x);

    	direction = new Vector2(0, 0);
    	timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	//this.transform.position =  new Vector2(Random.Range(left_x, right_x), this.transform.position.y);

    	timeElapsed += Time.deltaTime;
    	Debug.Log(timeElapsed);

    	if (this.transform.position.y <= lower_y)
    	{
    		direction = Vector2.up;
    	}

    	else if (this.transform.position.y >= upper_y)
    	{
    		//timer
    		if (timeElapsed >= interval)
    		{
    			direction = Vector2.down;
    			timeElapsed = 0;
    		}
    		else
    		{
    			direction = new Vector2(0, 0);
    		}
    	}

    	Move(speed);
    }

    void Move(float speed)
    {
    	this.transform.Translate(direction * speed);
    }

}
