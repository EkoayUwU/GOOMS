using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IA_Rat_Movement : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] ZoneDetection zoneRef;
    [SerializeField] MovingPlatform platformRef;

    [SerializeField] Transform[] Waypoints;
    int indexWaypoints;
    Transform target;
    int direction = -1;

    [SerializeField] float movementSpeed;
    Rigidbody2D rb;
    Vector2 ref_velocity = Vector2.zero;

    [SerializeField] bool isChasing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = Waypoints[0];
    }


    void Update()
    {

        isChasing = ((CheckGauche() || CheckDroite()) && zoneRef.Get()) ? true : false;


        target = Waypoints[indexWaypoints % Waypoints.Length];
        Vector3 directionTarget = target.position - gameObject.transform.position;
        direction = directionTarget.x > 0 ? 1 : -1;

        if (Vector2.Distance(transform.position, target.position) < 2f)
        {
            indexWaypoints++;
            rb.velocity = direction == 1 ? new Vector2(2f, 0) : new Vector2(-2f, 0);
            target = Waypoints[indexWaypoints % Waypoints.Length];
            SwapSens();
        }
    }

    private void FixedUpdate()
    {

        if (isChasing)
        {
            movementSpeed = 800f;
        }

        else
        {
            movementSpeed = 550f;
        }

        Vector2 target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, 0);

        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);
    }

    bool CheckGauche()
    {
        return (((playerRef.transform.position.x - transform.position.x < 0) && transform.localScale.x == -1) && !platformRef.Get()) ? true : false;
    }

    bool CheckDroite()
    {
        return (((playerRef.transform.position.x - transform.position.x > 0) && transform.localScale.x == 1) && !platformRef.Get()) ? true : false;
    }

    private void SwapSens()
    {
        transform.localScale = target.position.x > transform.position.x ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
    }
}
