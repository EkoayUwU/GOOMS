using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMouvement : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            function(transform.position.x);
        }
    }
    void function(float pos)
    { 
        Debug.Log("Coord: " + 0.5* (pos*pos));
    }
}

