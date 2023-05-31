using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    [SerializeField] bool isAscending;
    SpriteRenderer sr;

    private void Start()
    {
        isAscending = false;

        sr = GetComponent<SpriteRenderer>();

        SetWater();

     
    }


    private void FixedUpdate()
    {
        if (isAscending && transform.position.y < 2.2f)
        {
            transform.position += new Vector3(0, Time.deltaTime * 0.75f, 0);
        } 
    }


    public void SetWater()
    {
        sr.enabled = true;
        isAscending = true;
    }
}
