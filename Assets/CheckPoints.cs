using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] GameObject PlayerSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerSpawn.SetActive(true);
            PlayerSpawn.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
