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
            Debug.Log("props reconnu");
            //Affichage Raycast
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * hitProps.distance, Color.green);           
        }
    }

}
