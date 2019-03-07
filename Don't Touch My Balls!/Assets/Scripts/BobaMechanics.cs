using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaMechanics : MonoBehaviour
{
    public GameObject straw;
    private Rigidbody2D boba;
    private Transform strawBox;

    // Start is called before the first frame update
    void Start()
    {
        boba = this.gameObject.GetComponent<Rigidbody2D>();
        straw = GameObject.Find("Straw");
        strawBox = straw.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (LevelManager.instance.vacuuming && boba.transform.position.x >= strawBox.position.x - 1.5f && boba.transform.position.x <= strawBox.position.x + 1.5f && boba.transform.position.y >= strawBox.position.y - 4 && boba.transform.position.y <= strawBox.position.y)
            boba.transform.position = Vector3.MoveTowards(boba.transform.position, straw.GetComponent<Collider2D>().bounds.min, LevelManager.instance.suction);
    }
}
