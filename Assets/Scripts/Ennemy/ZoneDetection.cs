using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    private bool inZone = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Attribu en True si le joueur est dans la zone
        if (collision.gameObject.name == "Player")
        {
            inZone = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Attribu en False si le joueur n'est pas dans la zone
        if (collision.gameObject.name == "Player")
        {
            inZone = false;
        }
    }

    public bool Get()
    {
        //Renvoie si le joueur est dans la zone
        return inZone;
    }
}
