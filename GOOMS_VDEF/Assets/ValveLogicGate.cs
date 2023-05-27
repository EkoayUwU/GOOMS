using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ValveLogicGate : MonoBehaviour
{
    [SerializeField] GameObject cursorRef;
    [SerializeField] LogicGate LogicGateRef;

    bool isWaiting;
    bool isWaiting2;
    bool isRotating;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting && isWaiting2)
        {
            LogicGateRef.Set(gameObject.name);
            isWaiting = false;
            isWaiting2 = false;
        }

        if (cursorRef.transform.position.x < transform.position.x + 1f && cursorRef.transform.position.x > transform.position.x - 1f && cursorRef.transform.position.y < transform.position.y + 1f && cursorRef.transform.position.y > transform.position.y - 1f)
        {
            if ((Input.GetMouseButton(0) || Input.GetAxis("RT") > 0))
            {
                if (isWaiting == false)
                {
                    isWaiting = true;
                    StartCoroutine(TimerValve());
                }
            }
        }

        if (isRotating) transform.Rotate(0, 0, 7.5f);


    }


    IEnumerator TimerValve()
    {
        isRotating = true;
        yield return new WaitForSeconds(0.77f);
        isRotating = false;
        isWaiting2 = true;

        //LightRef.GetComponent<SpriteRenderer>().sprite = green_light;
        //ValveLight.color = Color.green;
    }
}
