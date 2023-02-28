using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeedHorizontal = 400f;
    float horizontalValue;
    float jumpForce = 7f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && canJump)
        {
            isJumping = true;
        }

        //Debug.Log(horizontalValue);
    }
    void FixedUpdate()
    {
        if (isJumping && canJump)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
        rb.velocity = new Vector2(horizontalValue*moveSpeedHorizontal*Time.fixedDeltaTime, rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            canJump = true;
        }
        
       
    }
}