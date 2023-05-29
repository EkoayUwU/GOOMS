using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMovement : MonoBehaviour
{
    GameObject PlayerRef;

    private void Start()
    {
        PlayerRef = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerRef.GetComponent<Player_Jump>().enabled = false;
      
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
