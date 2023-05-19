using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsGrabReach : MonoBehaviour
{
    bool onReach;
    GameObject PropsRef;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        onReach = collision.name == "PROPS" && collision.gameObject.layer == 8 ? true : false;
        PropsRef = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onReach = false;
    }

    public bool GetOnReach()
    {
        return onReach;
    }

    public GameObject GetProps()
    {
        return PropsRef;
    }
}
