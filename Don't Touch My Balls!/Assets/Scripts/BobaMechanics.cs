using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaMechanics : MonoBehaviour
{
    public GameObject straw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (LevelManager.instance.vacuuming)
            StrawVacuum();
    }

    void StrawVacuum()
    {

    }
}
