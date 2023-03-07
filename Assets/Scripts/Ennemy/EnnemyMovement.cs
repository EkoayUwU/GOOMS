using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] ZoneDetection zoneRef;
    [SerializeField] MovingPlatform platformRef;

    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField] Transform[] waypoints;
    private int indexWaypoints = 0;
    private Transform target;
    private int direction = 0;
    private Vector2 directionTarget;


    Vector2 target_velocity;
    [SerializeField] float movementSpeed = 400f;
    Vector2 ref_velocity = Vector2.zero;

    bool aggroTaken = false;


    void Start()
    {
        target = waypoints[0];

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        bool CheckGauche()
        {
            return (((transform.position.x >= playerRef.transform.position.x) && (transform.localScale.x == -1) && (zoneRef.Get()))) ? true : false;
        }
        bool CheckDroite()
        {
            return (((transform.position.x <= playerRef.transform.position.x) && (transform.localScale.x == 1) && (zoneRef.Get()))) ? true : false;
        }
        bool Aggro()
        {
            return ((CheckGauche() || CheckDroite()) && !platformRef.Get()) ? true : false;
        }


        if (Aggro())
        {
            aggroTaken = true;
            movementSpeed = 800f;
            
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;
                       
        }

        else
        {         
            movementSpeed = 400f;
            target = waypoints[indexWaypoints % waypoints.Length];
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;

            //Swap Direction
            if (Vector2.Distance(transform.position, target.position) < 1.0f)
            {
                indexWaypoints++;
                rb.velocity = direction == 1 ? new Vector2(2f, 0) : new Vector2(-2f, 0);            
                target = waypoints[indexWaypoints % waypoints.Length];
            }
            SwapSens();
        }

        Debug.Log("aggroTaken " + aggroTaken + " ;zoneRef.Get() " + zoneRef.Get() + " ;!Aggro() " + !Aggro());

        if (aggroTaken && zoneRef.Get() && !Aggro())
        {           
            target = playerRef.transform;
            indexWaypoints++;
            SwapSens();
            aggroTaken = false;
        }

    }

    private void FixedUpdate()
    {
            target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);       
    }
    private void SwapSens()
    {
        transform.localScale = target.position.x > transform.position.x ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
    }

}
