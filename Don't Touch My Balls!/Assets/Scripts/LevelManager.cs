using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
    public bool isGameOver;
    public float startTime = 60f;
	public float timeRemaining;

    public int bobaQuantity = 20;

    void Awake()
    {
        //depending on drink size, will change timer and amount of boba etc.
    	instance = this;
        timeRemaining = startTime;
        isGameOver = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
