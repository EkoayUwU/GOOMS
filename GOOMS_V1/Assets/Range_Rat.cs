using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Rat : MonoBehaviour
{
    [SerializeField] GameObject playerRef;

    [SerializeField] GameObject Bullet;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] Transform rangeRef;
    bool isWaiting = false;

    float range;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position,playerRef.transform.position);

        if (range < Vector2.Distance(transform.position, rangeRef.position) && !isWaiting)
        {
            Debug.Log("isIn");
            isWaiting = true;            
            StartCoroutine(Timer());
        }
    }


    void Shoot()
    {

        Instantiate(Bullet, bulletSpawnPos.position, Quaternion.identity);
        Debug.Log("Shoot");
    }

    IEnumerator Timer()
    {
        Debug.Log("Timer");
        Shoot();
        yield return new WaitForSeconds(2);
        isWaiting = false;

    }
}
