using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.timeRemaining <= 0)
            LevelManager.instance.timeRemaining = 0;

        timerText.text = string.Format("{0:0.00}", LevelManager.instance.timeRemaining);
    }
}
