using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] bool onProps = false;
    [SerializeField] bool forcedDrop = false;
    [SerializeField] GameObject refToDraggedProps;
    [SerializeField] GameObject draggedProps;
    Rigidbody2D rbDP;

    GameObject[] LimiteRefList;
    private void Start()
    {
        LimiteRefList = GameObject.FindGameObjectsWithTag("LimiteRef");
    }


    void Update()
    {
        if(Gamepad.current != null)
        {
            if (Input.GetAxis("RT") > 0 && onProps && !forcedDrop)
            {
                draggedProps = refToDraggedProps;
                draggedProps.layer = 9;
                rbDP = draggedProps.GetComponent<Rigidbody2D>();
                rbDP.gravityScale = 0;
                rbDP.angularDrag = 2.5f;
                draggedProps.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 125);


                rbDP.constraints = RigidbodyConstraints2D.None;
                rbDP.constraints = RigidbodyConstraints2D.FreezePosition;

                if(LimiteRefList != null)
                {
                    foreach (GameObject Limite in LimiteRefList)
                    {
                        Limite.SetActive(true);
                    }
                }
                
            }
            if (Input.GetAxis("RT") <= 0 && draggedProps != null)
            {
                draggedProps.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                draggedProps.layer = 8;
                rbDP.gravityScale = 1.5f;
                rbDP.constraints = RigidbodyConstraints2D.FreezeAll;
                draggedProps = null;

                if (LimiteRefList != null)
                {
                    foreach (GameObject Limite in LimiteRefList)
                    {
                        Limite.SetActive(false);
                    }
                }
            }

            //if (Input.GetAxis("LT") > 0 && draggedProps)
            //{
            //    forcedDrop = true;
            //    rbDP.constraints = RigidbodyConstraints2D.FreezeAll;
            //    draggedProps.layer = 8;
            //    draggedProps = null;
            //}
        }

        else
        {
            if (Input.GetMouseButtonDown(0) && onProps && !forcedDrop)
            {
                draggedProps = refToDraggedProps;
                draggedProps.layer = 9;
                rbDP = draggedProps.GetComponent<Rigidbody2D>();
                rbDP.gravityScale = 0;
                rbDP.angularDrag = 2.5f;
                draggedProps.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 125);

                rbDP.constraints = RigidbodyConstraints2D.None;
                rbDP.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            if (Input.GetMouseButtonUp(0) && draggedProps != null)
            {
                draggedProps.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                draggedProps.layer = 8;
                rbDP.gravityScale = 1.5f;
                rbDP.constraints = RigidbodyConstraints2D.FreezeAll;
                draggedProps = null;

            }

            //if (Input.GetMouseButtonDown(1) && draggedProps)
            //{
            //    forcedDrop = true;
            //    rbDP.constraints = RigidbodyConstraints2D.FreezeAll;
            //    draggedProps.layer = 8;
            //    draggedProps = null;
            //}
        }
        

        if (forcedDrop) Invoke("Timer", 1.0f);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            refToDraggedProps = collision.gameObject;
            onProps = true;
        }
        //Debug.Log(collision.gameObject.name);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            onProps = false;
            refToDraggedProps = null;
        }       
    }

    private void FixedUpdate()
    {
        if(draggedProps != null) 
        {
            draggedProps.transform.position = transform.position;
        }
    }

    void Timer()
    {
        forcedDrop = false;
    }
}
