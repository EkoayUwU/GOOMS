using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    [SerializeField] Inventory Inventory;
    [SerializeField] int value = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (gameObject)
            {
                Inventory.SetCoins(value);
            }            
            Debug.Log(Inventory.GetCoins());                       
            Destroy(gameObject);
        }
    }
}
