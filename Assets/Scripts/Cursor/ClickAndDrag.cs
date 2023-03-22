using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    //Curseur
    [SerializeField] GameObject obstacleRayObject;
    //taille raycast
    [SerializeField] float obstacleRayDistance;
    //layer Mask Props
    [SerializeField] LayerMask layerMask;


    Vector2 mousePosition;
    Vector2 ref_velocity = Vector2.zero;

    private Rigidbody2D hittedProps;
    GameObject hittedObject;

   
 

    void Update()
    {
        //Cr�ation RayCastHit avec position curseur + direction + taille + layerMask qu'il doit reconna�tre
        //RaycastHit2D isHitRay = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D isHitRay;

        //Unfreeze props + retirer velocit�/gravit� pdnt drag + cr�ation parent pour rotation props 
        if (Input.GetMouseButtonDown(0))
        {
            isHitRay = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);
            if (isHitRay && isHitRay.transform.tag == "staticProps")
            {
                
                hittedProps = isHitRay.transform.gameObject.GetComponent<Rigidbody2D>();
                hittedObject = isHitRay.transform.gameObject;
                hittedObject.tag = "mouvingProps";
                hittedObject.layer = 11;
                hittedProps.gravityScale = 0f;
                hittedProps.constraints = RigidbodyConstraints2D.None;
                hittedProps.angularDrag = 2.5f;
                
            }
        }


        //Freeze le props avec RMB 
        if (Input.GetMouseButtonDown(1) && hittedObject)
        {
            hittedProps.constraints = RigidbodyConstraints2D.FreezeAll;
            hittedObject.tag = "staticProps";
            hittedObject.layer = 10;
            hittedObject = null;
        }

        //clear la variable qui stock le props s�l�ction� lors du relachement de LMB
        if (Input.GetMouseButtonUp(0) && hittedObject)
        {
            hittedProps.gravityScale = 1f;
            hittedObject.tag = "staticProps";
            hittedObject.layer = 10;
            hittedProps = null;    
            
            hittedObject = null;

        }
    }


    private void FixedUpdate()
    {
        //D�placement props
        if(hittedProps) hittedProps.MovePosition(Vector2.SmoothDamp(hittedProps.transform.position, mousePosition, ref ref_velocity, 0f));
    }
}