using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] VisionDetector visionDetector;
    [SerializeField] GameObject playerRef;

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
        
        if (visionDetector.inVisionCone() && waypoints[0].transform.position.x < transform.position.x && transform.position.x < waypoints[1].transform.position.x )
        {
            target = playerRef.transform;
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;

        }

        if (!visionDetector.inVisionCone())
        {
            target = waypoints[indexWaypoints % waypoints.Length];
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;

            //Swap Direction
            if (Vector2.Distance(transform.position, target.position) < 1.0f)
            {
                indexWaypoints++;
                rb.velocity = direction == 1 ? new Vector2(2f, 0) : new Vector2(-2f, 0);
                transform.localScale = direction == 1 ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
                target = waypoints[indexWaypoints % waypoints.Length];
                Debug.Log(target);
            }
        }
        

        

        
    }

    private void FixedUpdate()
    {
        if (visionDetector.inVisionCone() && Vector2.Distance(transform.position, target.position) > 0)
        {
            target_velocity = new Vector2((Vector2.Distance(transform.position, target.position) * direction * movementSpeed * Time.deltaTime) / 4, rb.velocity.y);
            Debug.Log(target_velocity);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);
        }

        else
        {
            target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);
        }
        

    }
    
}
