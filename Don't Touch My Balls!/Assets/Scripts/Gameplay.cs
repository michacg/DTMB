using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{ 
    public GameObject leftBound;
    public GameObject rightBound;
    public List<Sprite> bobaSprites;
    public GameObject bobaObj;

    private SpriteRenderer prefabSprite;

    void Awake()
    {
        prefabSprite = bobaObj.GetComponent<SpriteRenderer>();    
        InstantiateBoba(LevelManager.instance.bobaQuantity);
    }

    void InstantiateBoba(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            Vector3 position    = new Vector3(Random.Range(leftBound.transform.position.x, rightBound.transform.position.x), 0, 0);
            prefabSprite.sprite = bobaSprites[Random.Range(0,4)];
            Instantiate(bobaObj, position, Quaternion.identity);
        }
    }
}
