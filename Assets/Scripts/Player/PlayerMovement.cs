// Importation des biblioth�ques
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    // D�claration des variables
    Rigidbody2D rb;
    float horizontalValue;
    [SerializeField] float moveSpeedHorizontal = 450f;
    [SerializeField] float jumpForce = 8.5f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Mise � jour
    void Update()
    {
        // R�cup�ration de la valeur horizontale de l'axe de d�placement
        horizontalValue = Input.GetAxis("Horizontal");

        // Gestion du saut
        if (Input.GetButtonDown("Jump") && canJump)
        {
            isJumping = true;
        }

        if (horizontalValue > 0) transform.localScale = new Vector3(1f, 1f, 1f);
        if (horizontalValue < 0) transform.localScale = new Vector3(-1f, 1f, 1f);

    }

    // Mise � jour fixe
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

        // D�placement horizontal
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