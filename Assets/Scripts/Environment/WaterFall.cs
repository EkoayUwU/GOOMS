using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFall : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    bool inWaterFall = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inWaterFall = true;
        }
    }

    private void Update()
    {
        if (inWaterFall)
            playerRef.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -25f);
    }
}
