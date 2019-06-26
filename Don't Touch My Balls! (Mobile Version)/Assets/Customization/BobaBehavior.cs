using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y <= -6)
            Destroy(this.gameObject);
    }
}
