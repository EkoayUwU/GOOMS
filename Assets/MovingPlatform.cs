using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    private bool OnPlatform = false;

    [SerializeField] Transform[] Waypoints;
    private Transform target;
    private int indexPoint = 0;

    private float speed = 3f;

    private void Start()
    {
        target = Waypoints[0];
    }


    private void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;

        void PlatformDeplacment(GameObject gameObject)
        {
            
            gameObject.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        
        PlatformDeplacment(gameObject);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            indexPoint ++;
            target = Waypoints[indexPoint % Waypoints.Length];
        }

        if (OnPlatform)
        {
            PlatformDeplacment(playerRef);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            OnPlatform = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            OnPlatform = false;
        }
        
    }

    public bool Get()
    {
        return OnPlatform;
    }
}
