using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMouvement : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] ZoneDetection zoneRef;
    Rigidbody2D rb;

    
    float speed = 7f;
    Vector2 target_velocity;
    Vector2 ref_velocity = Vector2.zero;

    bool isChasing = false;
    bool lowest = false;
    bool timer = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   

        if (!zoneRef.Get() || lowest)
        {
            isChasing = false;
            rb.velocity = new Vector2(0, 10f);

            timer = false;
            
            
        }
        if (!timer)
        {
            timer = true;
            Invoke("timeLowest", 1.25f);
        }
        if (zoneRef.Get() && !isChasing)
        {
            Debug.Log(isChasing);
            rb.velocity = Vector2.zero;
            isChasing = true;
            
        }
        if (isChasing && !lowest)
        {
            
            lowest = transform.position.y > playerRef.transform.position.y ? false : true;
            Debug.Log("chase call");
           
            Vector3 direction = playerRef.transform.position - transform.position;

            gameObject.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        }
    }
    void timeLowest()
    {
        lowest = false;
        timer = false;
    }

}
