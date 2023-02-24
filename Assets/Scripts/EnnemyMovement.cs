using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 target_velocity;
    [SerializeField] Transform[] waypoints;
    private Transform target;
    private int direction = 0;

    private int indexWaypoints = 0;

    [SerializeField] float movementSpeed = 400f;
    Vector2 ref_velocity = Vector2.zero;



    

    void Start()
    {
        target = waypoints[0];

        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        

       
        Vector2 directionTarget = target.position - gameObject.transform.position;

        direction = directionTarget.x > 0 ? 1 : -1;
        
        if ((transform.position.x - target.position.x) < 1.0f)
        {
            indexWaypoints++;
            rb.velocity = ref_velocity;
            target = waypoints[indexWaypoints % waypoints.Length];
            Debug.Log(target);
        }

        
    }

    private void FixedUpdate()
    {
        target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);

    }
    
}
