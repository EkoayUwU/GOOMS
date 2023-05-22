using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    Animator anim;
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
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        coyoteTimeCounter = isGrounded ? coyoteTime : coyoteTimeCounter - Time.deltaTime;

        jumpBufferCounter = Input.GetButtonDown("Jump") && isGrounded? jumpBufferTime : jumpBufferCounter - Time.deltaTime;

        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump") && !isJumping)
        {
            anim.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }  

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform" || collision.gameObject.tag == "staticProps")
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;         
        }
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
