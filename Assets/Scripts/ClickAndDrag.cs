using System.Collections;
using System.Collections.Generic;
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

    
    
    void Start()
    {
        
    }

    void Update()
    {
        //Création RayCastHit avec position curseur + direction + taille + layerMask qu'il doit reconnaître
        RaycastHit2D isHitRay = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);
   
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Unfreeze props + retirer velocité/gravité pdnt drag + création parent pour rotation props 
        if (Input.GetMouseButtonDown(0) && isHitRay)
        {
            hittedProps = isHitRay.transform.gameObject.GetComponent<Rigidbody2D>();

            hittedProps.velocity = Vector2.zero;
            hittedProps.gravityScale = 0f;
            hittedProps.constraints = RigidbodyConstraints2D.None;
        }


        //Freeze le props avec RMB 
        if (Input.GetMouseButtonDown(1) && isHitRay)
        {
            hittedProps.constraints = RigidbodyConstraints2D.FreezeAll;           
        }  
        
        //clear la variable qui stock le props séléctioné lors du relachement de LMB
        if (Input.GetMouseButtonUp(0) && hittedProps)
        {
            hittedProps.gravityScale = 1f;
            hittedProps = null;            
        }          
    }

    
    private void FixedUpdate()
    {
        //Déplacement props
        if (hittedProps)
        {
            hittedProps.MovePosition(Vector2.SmoothDamp(hittedProps.transform.position, mousePosition, ref ref_velocity, 0f));
        }
    }
}
