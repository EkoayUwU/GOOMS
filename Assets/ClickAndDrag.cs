using System.Collections;
using System.Collections.Generic;
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

    Rigidbody2D hittedProps;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Création RayCastHit avec position curseur + direction + taille + layerMask qu'il doit reconnaître
        RaycastHit2D isHitRay = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);
   
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Unfreeze props + retirer velocité/gravité pdnt drag
        if (Input.GetMouseButtonDown(0) && isHitRay)
        {
            hittedProps = isHitRay.transform.gameObject.GetComponent<Rigidbody2D>(); 
            hittedProps= hittedProps.GetComponent<Rigidbody2D>();

            hittedProps.velocity = Vector2.zero;

            hittedProps.constraints = RigidbodyConstraints2D.None;
        }

        //Freeze le props
        if (Input.GetMouseButtonDown(1) && isHitRay)
        {
            hittedProps.constraints = RigidbodyConstraints2D.FreezeAll;
        }  
        
        //
        if (Input.GetMouseButtonUp(0) && hittedProps)
        {
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
