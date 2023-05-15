using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealthRef;
    int dmg = 1;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            Debug.Log("hit");
            playerHealthRef.Damage(dmg);
        }
    }
}
