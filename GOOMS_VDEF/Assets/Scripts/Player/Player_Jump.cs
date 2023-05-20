using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    //public float jumpForceMin = 5f; // Force minimale du saut
    //public float jumpForceMax = 10f; // Force maximale du saut
    //public float jumpTime = 1f; // Durée totale du saut
    //private float jumpTimer; // Timer du saut
    //private bool isJumping; // Indique si le joueur est en train de sauter
    //private bool jumpInputReleased; // Indique si la touche de saut a été relâchée
    //[SerializeField] bool canJump;

    //private Rigidbody2D rb;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Jump") && canJump)
    //    {
    //        StartJump();
    //    }

    //    if (Input.GetButtonUp("Jump"))
    //    {
    //        jumpInputReleased = true;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (isJumping)
    //    {
    //        UpdateJump();
    //    }
    //}

    //private void StartJump()
    //{
    //    isJumping = true;
    //    jumpTimer = 0f;
    //    jumpInputReleased = false;
    //    rb.velocity = new Vector2(rb.velocity.x, jumpForceMin);
    //}

    //private void UpdateJump()
    //{
    //    jumpTimer += Time.fixedDeltaTime;

    //    if (jumpTimer <= jumpTime)
    //    {
    //        float normalizedTime = jumpTimer / jumpTime;
    //        float jumpForce = Mathf.Lerp(jumpForceMin, jumpForceMax, normalizedTime);
    //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //    }
    //    else
    //    {
    //        isJumping = false;
    //    }

    //    if (jumpInputReleased)
    //    {
    //        isJumping = false;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    canJump = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    canJump = false;
    //}
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;

    float jumpForce = 16f;

    float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    float jumpBufferTime = 0.005f;
    float jumpBufferCounter;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        coyoteTimeCounter = isGrounded ? coyoteTime : coyoteTimeCounter - Time.deltaTime;

        jumpBufferCounter = Input.GetButtonDown("Jump") && isGrounded? jumpBufferTime : jumpBufferCounter - Time.deltaTime;

        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }  

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name != "GrabReach") isGrounded = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "GrabReach") isGrounded = false;
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}
