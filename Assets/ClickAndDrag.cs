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

    RaycastHit2D isHitRay;

    [SerializeField] bool isProps;
    Vector2 mousePosition;
    Rigidbody2D hittedProps;
    Vector2 ref_velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Création RayCastHit avec position curseur + direction + taille + layerMask qu'il doit reconnaître
        isHitRay = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);
        

        //Si Curseur sur props
        if (isHitRay.collider)
        {            
            //Affichage Raycast
            //Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * isHitRay.distance, Color.green);
            isProps = true;
        }
        else
        {
            isProps = false;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && isProps)
        {
            hittedProps = isHitRay.transform.gameObject.GetComponent<Rigidbody2D>(); 
            hittedProps= hittedProps.GetComponent<Rigidbody2D>();

            hittedProps.velocity = Vector2.zero;
        }

                        
        if (Input.GetMouseButtonUp(0) && hittedProps)
        {

            hittedProps = null;
        }       
    }

    private void FixedUpdate()
    {
        if (hittedProps)
        {
            hittedProps.MovePosition(Vector2.SmoothDamp(hittedProps.transform.position, mousePosition, ref ref_velocity, 0f));
            
        }
    }

}
