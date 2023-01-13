using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Récup position souris en convertissant pos caméra en pos World
        //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Debug.Log(mousePosition);
        //}
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

        //    if (targetObject && targetObject.tag == "props")
        //    {
        //        selectedObject = targetObject.transform.gameObject;
        //    }

        //}
        // Creates a Ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin, ray.direction * 10);
        if (Physics.Raycast(ray, out hitData))
        {
            // The Ray hit something!
        }






    }

}
