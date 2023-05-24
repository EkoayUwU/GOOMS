using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] CameraFollowObject _cameraFollowObject;
    [SerializeField] CameraSmoothFlip _cameraNoY;
    bool isRotating = false;
    Rigidbody2D rb;
    Animator anim;

    //Variable mouvement horizontal
    float horizontalValue;
    [SerializeField] float movementSpeed;

    //Variable Camera
    public bool isFacingRight = true;
    float _fallSpeedYDampingChangeThreshold; 



    void Start()
    {
        //ref rigidbody2D player
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _fallSpeedYDampingChangeThreshold = CameraManager.instance._fallSpeedYDampingChangeThreshold;
    }


    void Update()
    {
        
        //récup valeur axe horizontal
        horizontalValue = Input.GetAxis("Horizontal") * 10;

        anim.SetFloat("Speed", Mathf.Abs(horizontalValue));

        #region Camera 

        //si vitesse > fallSpeedThreshold, modifie damping Y de la cam pour un décalage lors de la chute
        if (rb.velocity.y < _fallSpeedYDampingChangeThreshold && !CameraManager.instance.isLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling) CameraManager.instance.LerpYDamping(true);
        //Si immobile ou mouvement vers le haut
        if (rb.velocity.y >= 0f && !CameraManager.instance.isLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling)    
        {
            //reset les get/set pour pouvoir être rappeler
            CameraManager.instance.LerpedFromPlayerFalling = false;
            CameraManager.instance.LerpYDamping(false);
        #endregion
        }
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
            _cameraNoY.CallTurn();
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.y);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;


            _cameraFollowObject.CallTurn();
            _cameraNoY.CallTurn();
        }
    }
}
