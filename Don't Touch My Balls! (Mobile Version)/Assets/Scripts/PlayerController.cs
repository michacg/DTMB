using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float speed = 5;

    // Joystick script
    public FloatingJoystick floatingJS;

	private Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        rb.AddForce(floatingJS.Direction.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);

		//if (Input.GetAxis("Horizontal") == 1)
		//{
		//	rb.AddForce( new Vector2(horizontal_speed * Time.deltaTime , 0), ForceMode2D.Impulse);
		//}

		//if (Input.GetAxis("Horizontal") == -1)
		//{
		//	rb.AddForce( new Vector2(-horizontal_speed * Time.deltaTime , 0), ForceMode2D.Impulse);
		//}

		//if (Input.GetAxis("Vertical") == 1)
		//{
		//	rb.AddForce( new Vector2(0 , vertical_speed * Time.deltaTime), ForceMode2D.Impulse);
		//}

		//if (Input.GetAxis("Vertical") == -1)
		//{
		//	rb.AddForce( new Vector2(0 , -vertical_speed * Time.deltaTime), ForceMode2D.Impulse);
		//}
	}
}
