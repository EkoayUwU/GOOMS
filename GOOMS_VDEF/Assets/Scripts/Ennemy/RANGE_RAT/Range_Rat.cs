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
    [SerializeField] bool isFacingRight;


    // Update is called once per frame
    void Update()
    {
        
        range = Vector2.Distance(new Vector2(transform.position.x,0), new Vector2(playerRef.transform.position.x,0));

        if (range < Vector2.Distance(transform.position, rangeRef.position) && !isWaiting)
        {
            isWaiting = true;            
            StartCoroutine(Timer());
        }
    }


    void Shoot()
    {
        Instantiate(Bullet, bulletSpawnPos.position, Quaternion.identity);
    }

    IEnumerator Timer()
    {
        Shoot();
        yield return new WaitForSeconds(1.25f);
        isWaiting = false;

    }
}
