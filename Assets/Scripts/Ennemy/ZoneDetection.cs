using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    private bool inZone = false;


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inZone = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            inZone = false;
        }
    }

    public bool Get()
    {
        return inZone;
    }
}
