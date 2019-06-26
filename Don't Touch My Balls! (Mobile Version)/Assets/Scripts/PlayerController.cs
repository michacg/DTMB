using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	public float horizontal_speed = 5;
	public float vertical_speed = 5;

	private Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetAxis("Horizontal") == 1)
		{
			rb.AddForce( new Vector2(horizontal_speed * Time.deltaTime , 0), ForceMode2D.Impulse);
		}

		if (Input.GetAxis("Horizontal") == -1)
		{
			rb.AddForce( new Vector2(-horizontal_speed * Time.deltaTime , 0), ForceMode2D.Impulse);
		}

		if (Input.GetAxis("Vertical") == 1)
		{
			rb.AddForce( new Vector2(0 , vertical_speed * Time.deltaTime), ForceMode2D.Impulse);
		}

		if (Input.GetAxis("Vertical") == -1)
		{
			rb.AddForce( new Vector2(0 , -vertical_speed * Time.deltaTime), ForceMode2D.Impulse);
		}

		
	}
}
