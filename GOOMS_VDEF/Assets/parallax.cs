using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class parallax : MonoBehaviour
{
    

    [SerializeField] float multiplier;
    [SerializeField] GameObject cameraRef;
    Vector3 startPosition;
    Vector3 startCameraPosition;

    private void Start()
    {
        startPosition = transform.position;
        startCameraPosition = cameraRef.transform.position;
        CalculateStartPosition();
    }

    private void FixedUpdate()
    {
        Vector3 position = startPosition;

        position.x += multiplier * (cameraRef.transform.position.x - startCameraPosition.x);

        transform.position = position;
    }

    void CalculateStartPosition()
    {
        float distX = (cameraRef.transform.position.x - transform.position.x) * multiplier;
        float distY = (cameraRef.transform.position.y - transform.position.y) * multiplier;
        Vector3 tmp = new Vector3(startPosition.x, startPosition.y);

        tmp.x = transform.position.x + distX;
       
        startPosition = tmp;
    }
}
