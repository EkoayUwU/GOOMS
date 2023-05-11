using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject Waterfall;
    [SerializeField] GameObject LightRef;
    [SerializeField] Sprite green_light;
    bool isOpen = false;
    private bool isWaiting = false;
    private bool isWaiting2 = false;

    void Update()
    {

        if (isWaiting && isWaiting2)
        {
            isOpen = !isOpen;
            isWaiting = false;
            isWaiting2 = false;

        }

        if (isOpen)
        {
            Waterfall.GetComponent<BoxCollider2D>().enabled = false;
            Waterfall.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (isWaiting == false)
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
        LightRef.GetComponent<SpriteRenderer>().sprite = green_light;
    }
}
