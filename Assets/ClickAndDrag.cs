using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    [SerializeField] bool isProps;
    //Curseur
    [SerializeField] GameObject obstacleRayObject;
    //taille raycast
    [SerializeField] float obstacleRayDistance;
    //layer Mask Props
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Création RayCastHit avec position curseur + direction + taille + layerMask qu'il doit reconnaître
        RaycastHit2D hitProps = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * 5, obstacleRayDistance, layerMask);

        //Si Curseur sur props
        if (hitProps.collider != null)
        {            
            //Affichage Raycast
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * hitProps.distance, Color.green);
            isProps = true;
        }
        else
        {
            isProps = false;
        }
    }

    private void FixedUpdate()
    {
        if (isProps)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(mousePosition + "UwU");
            }
        }
    }

}
