using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveSystem : MonoBehaviour
{
    [SerializeField] LogicGateValve LogicGateValve;
    private bool isWaiting = false;
    private bool isWaiting2 = false;

    

    void Update()
    {

        if (isWaiting && isWaiting2)
        {
            LogicGateValve.Set(gameObject.name);
            isWaiting = false;
            isWaiting2 = false;
            
        }
    }
        
            
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if(isWaiting == false)
            {
                isWaiting = true;
                StartCoroutine(TimerVavle());
            }
            
        }
    }

    IEnumerator TimerVavle()
    {
        yield return new WaitForSeconds(0.75f);
        isWaiting2 = true;
    }
}
