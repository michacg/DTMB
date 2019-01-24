using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	public float speed = 5;

	private Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(Input.GetAxis("Vertical"));
		if (Input.GetAxis("Horizontal") == 1)
		{
			rb.AddForce( new Vector2(speed * Time.deltaTime , 0));
		}

		if (Input.GetAxis("Horizontal") == -1)
		{
			rb.AddForce( new Vector2(-speed * Time.deltaTime , 0));
		}

		if (Input.GetAxis("Vertical") > 1)
		{
			rb.AddForce( new Vector2(0 , speed * Time.deltaTime));
		}

		if (Input.GetAxis("Horizontal") < -1)
		{
			rb.AddForce( new Vector2(0 , -speed * Time.deltaTime));
		}

		
	}
}
