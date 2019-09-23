using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sten : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0f;
        }
        
    }
}


