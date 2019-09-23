using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tid : MonoBehaviour
{
    float Timer = 0.0f;
    public TextMeshProUGUI TimerText;

    void Update()
    {
       
       Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
        TimerText.text = Timer.ToString("n1");

    }
}
