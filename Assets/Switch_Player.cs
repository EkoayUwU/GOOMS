using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Player : MonoBehaviour
{
    [SerializeField] GameObject Bluey_ref;
    [SerializeField] GameObject Bingo_ref;

    Vector3 refVelocity = Vector3.zero;
    float smoothTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Bluey_ref.GetComponent<Player>().enabled = true;
        Bingo_ref.GetComponent<Player>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Bluey_ref.GetComponent<Player>().enabled = false;
            Bluey_ref.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Bingo_ref.GetComponent<Player>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.R)) 
        {
            Bluey_ref.GetComponent<Player>().enabled = true;
            Bingo_ref.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Bingo_ref.GetComponent<Player>().enabled = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (Bluey_ref.GetComponent<Player>().enabled)
        {
            Vector3 targetPosition = new Vector3(Bluey_ref.transform.position.x, Bluey_ref.transform.position.y, -10);
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref refVelocity, smoothTime);
        }
        else if (Bingo_ref.GetComponent<Player>().enabled)
        {
            Vector3 targetPosition = new Vector3(Bingo_ref.transform.position.x, Bingo_ref.transform.position.y, -10);
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref refVelocity, smoothTime);
        }
    }

}
