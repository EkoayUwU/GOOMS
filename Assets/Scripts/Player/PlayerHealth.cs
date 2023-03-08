using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement movementScript;
    private BoxCollider2D boxCollider;
    private CapsuleCollider2D capCollider;
    private SpriteRenderer sr;

    private int healthPoint;
    private bool isGrounded = false;

    void Start()
    {
        healthPoint = 1;
        rb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();

        boxCollider = rb.GetComponent<BoxCollider2D>();
        capCollider = rb.GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        
        if(healthPoint <= 0)
        {
            movementScript.enabled = false;
            sr.color = new Color(255f, 0f, 0f);

            if (isGrounded)
            {                
                rb.bodyType = RigidbodyType2D.Static;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            

            /*  Lancement Animation + Ecran Mort
                Juuuuuuuuste ici
                Là
            */

        }
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            Damage(1);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Floor" || collision.tag == "Platform")
        {
            isGrounded = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
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
