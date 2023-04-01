// Importation des bibliothèques
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Déclaration des variables
    Rigidbody2D rb;
    float moveSpeedHorizontal = 450f;
    float horizontalValue;
    float jumpForce = 8.5f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Mise à jour
    void Update()
    {
        // Récupération de la valeur horizontale de l'axe de déplacement
        horizontalValue = Input.GetAxis("Horizontal");

        // Gestion du saut
        if (Input.GetButtonDown("Jump") && canJump)
        {
            isJumping = true;
        }
    }

    // Mise à jour fixe
    void FixedUpdate()
    {
        // Gestion du saut
        if (isJumping && canJump)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;

            // Coroutine pour la chute
            if (!canJump)
            {
                StartCoroutine(FallTime());
            }
        }

        // Déplacement horizontal
        rb.velocity = new Vector2(horizontalValue * moveSpeedHorizontal * Time.fixedDeltaTime, rb.velocity.y);
    }

    // Gestion de la collision avec le sol
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || collision.tag == "Platform" || collision.tag == "staticProps")
        {
            rb.gravityScale = 1;
            canJump = true;
        }

    }

    // Gestion de la sortie de la collision avec le sol
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

    // Coroutine pour la chute
    IEnumerator FallTime()
    {
        if (canJump == false)
        {
            yield return new WaitForSeconds(0.3f);
            rb.gravityScale = 2.5f;
        }
    }
}