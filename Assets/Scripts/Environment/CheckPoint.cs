using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] spawnManager spawnManager;
    [SerializeField] Sprite greenFlag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            
            spawnManager.SetSpawnPosition(transform.position);
            GetComponent<SpriteRenderer>().sprite = greenFlag;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
