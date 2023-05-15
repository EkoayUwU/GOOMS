using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWaterfall : MonoBehaviour
{
    [SerializeField] float timerTime;
    bool isActive = true;
    bool isTimed = false;


    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = isActive ? true : false;
        
        if (!isTimed)
        {
            isTimed = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timerTime);
        isActive = !isActive;
        isTimed = false;
    }
    
}
