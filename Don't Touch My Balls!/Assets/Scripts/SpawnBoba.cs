using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoba : MonoBehaviour
{

	public GameObject BobaObject;

	public GameObject leftBound;
	public GameObject rightBound;

	private float left_x;
	private float right_x;

    void Awake()
    {
    	left_x = leftBound.transform.position.x;
    	right_x = rightBound.transform.position.x;
        
    }

    void Start()
    {
    	InstantiateBoba(LevelManager.instance.bobaQuantity);
    }

    void InstantiateBoba(int n)
    {

        for (int i = 0; i < n; ++i)
        {
        	Vector3 position = new Vector3(Random.Range(left_x,right_x), 0, 0);
            Instantiate(BobaObject, position, Quaternion.identity);
        }
    }

}
