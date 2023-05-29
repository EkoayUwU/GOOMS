using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject cursorRef;

    [SerializeField] GameObject Waterfall;
    [SerializeField] GameObject LightRef;
    [SerializeField] Sprite green_light;
    [SerializeField] Light2D ValveLight;

    bool isOpen = false;
    private bool isWaiting = false;
    private bool isWaiting2 = false;

    bool isRotating = false;

    void Update()
    {

        if (isWaiting && isWaiting2)
        {
            isOpen = true;
            isWaiting = false;
            isWaiting2 = false;
        }

        if (isOpen)
        {
            Waterfall.SetActive(false);
        }

        if (cursorRef.transform.position.x < transform.position.x + 1f && cursorRef.transform.position.x > transform.position.x - 1f && cursorRef.transform.position.y < transform.position.y + 1f && cursorRef.transform.position.y > transform.position.y - 1f)
        {
            if ((Input.GetMouseButton(0) || Input.GetAxis("RT") > 0) && !isOpen)
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
        LightRef.GetComponent<SpriteRenderer>().sprite = green_light;
        ValveLight.color = Color.green;
    }
}
