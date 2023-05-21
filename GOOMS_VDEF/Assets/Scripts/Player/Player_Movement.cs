using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] CameraFollowObject _cameraFollowObject;
    bool isRotating = false;
    Rigidbody2D rb;
    Animator anim;

    //Variable mouvement horizontal
    float horizontalValue;
    [SerializeField] float movementSpeed;

    public bool isFacingRight = true;


    void Awake()
    {
        //ref rigidbody2D player
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        
        //récup valeur axe horizontal
        horizontalValue = Input.GetAxis("Horizontal") * 10;

        anim.SetFloat("Speed", Mathf.Abs(horizontalValue));
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0 && !isFacingRight) Turn();
        else if (Input.GetAxis("Horizontal") < 0 && isFacingRight) Turn();

        //Déplacement horizontal player
        rb.velocity = new Vector2(horizontalValue * movementSpeed * Time.deltaTime, rb.velocity.y);
    }

    void Turn()
    {
        if(isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.y);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;

            _cameraFollowObject.CallTurn();
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.y);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;


            _cameraFollowObject.CallTurn();
        }
    }
}
