using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement movementScript;
    private BoxCollider2D boxCollider;
    private CapsuleCollider2D capCollider;

    private int healthPoint;

    void Start()
    {
        healthPoint = 1;
        rb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovement>();

        boxCollider = rb.GetComponent<BoxCollider2D>();
        capCollider = rb.GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        if(healthPoint <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movementScript.enabled = false;
            boxCollider.enabled = false;
            capCollider.enabled = false;

            /*  Lancement Animation + Ecran Mort
                Juuuuuuuuste ici
                Là
            */

        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            Damage(1);
        }
    }

    public void SetHealth(int health)
    {
        healthPoint = health;
    }
    public void Damage(int dmg)
    {
        healthPoint -= dmg;
    }






}
