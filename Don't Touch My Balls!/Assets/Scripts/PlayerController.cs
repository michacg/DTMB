using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetAxis("Horizontal") == 1)
		{
			gameObject.rigidbody.AddForce(Vector2(speed * Time.deltatime , 0));
		}

		if (Input.GetAxis("Horizontal") == -1)
		{

		}

		if (input.GetAxis("Vertical") == 1)
		{

		}

		if (Input.GetAxis("Horizontal") == -1)
		{

		}

		
	}
}
