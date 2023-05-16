using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    //Variable mouvement horizontal
    float horizontalValue;
    [SerializeField] float movementSpeed;


    void Start()
    {
        //ref rigidbody2D player
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //sens player
        transform.localScale = horizontalValue > 0 ? new Vector3(1, 1, 1) : horizontalValue == 0 ? transform.localScale : new Vector3(-1,1,1);

        //récup valeur axe horizontal
        horizontalValue = Input.GetAxis("Horizontal");

        if (horizontalValue != 0) anim.SetFloat("Speed", Mathf.Abs(horizontalValue));
    }

    private void FixedUpdate()
    {
        //Déplacement horizontal player
        rb.velocity = new Vector2(horizontalValue * movementSpeed * Time.deltaTime, rb.velocity.y);
    }
}
