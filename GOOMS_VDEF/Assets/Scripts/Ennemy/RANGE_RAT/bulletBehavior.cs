using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] Transform rangeRef;

    Rigidbody2D rb;
    [SerializeField] float travelSpeed;
    Vector2 ref_velocity = Vector2.zero;
    

    void Start()
    {
        //StartCoroutine(LifeTimer());
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(playerRef.transform.position.x, 0)) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 target_velocity = new Vector2(-1 * travelSpeed * Time.deltaTime, 0);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity,ref ref_velocity, 0.5f);
    }

    //IEnumerator LifeTimer()
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
