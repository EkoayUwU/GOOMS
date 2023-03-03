using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] ZoneDetection ZoneRef;

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


    void Start()
    {
        target = waypoints[0];

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
        if (((transform.position.x > playerRef.transform.position.x) && (transform.localScale.x == -1) && (ZoneRef.Get())) || ((transform.position.x < playerRef.transform.position.x) && (transform.localScale.x == 1) && (ZoneRef.Get())))
        {
            movementSpeed = 800f;
            target = playerRef.transform;
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
        }

        //Swap le sens du perso
        transform.localScale = target.position.x > transform.position.x ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);

    }

    private void FixedUpdate()
    {
            target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);       
    }
    
}
