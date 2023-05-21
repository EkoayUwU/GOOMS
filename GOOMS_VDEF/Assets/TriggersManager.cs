using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersManager : MonoBehaviour
{
    private Collider2D _coll;

    private void Start()
    {
        _coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector2 exitDirection = (collision.transform.position - _coll.bounds.center).normalized;

            //swap Camera
            if (exitDirection.x > 0f)
            {
                _coll.enabled = false;
            } 
        }
    }
}
