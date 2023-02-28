using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : MonoBehaviour
{
    private bool isDetected = false;

    private void Update()
    {
        Debug.Log(isDetected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( isDetected) 
        { 
            isDetected = false;
        }
    }

    public bool inVisionCone()
    {
        return isDetected;
    }
}
