using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPosition : MonoBehaviour
{
    [SerializeField] GameObject cameraRef;
    [SerializeField] float camSpeed;
    void Update()
    {
        float tailleCam = cameraRef.GetComponent<Camera>().orthographicSize;

        if (transform.position.x < cameraRef.transform.position.x - tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x - tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.x > cameraRef.transform.position.x + tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x + tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.y < cameraRef.transform.position.y - tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y - tailleCam, transform.position.z);
        if (transform.position.y > cameraRef.transform.position.y + tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y + tailleCam, transform.position.z);


        if (Gamepad.current != null)
        {
            //Debug.Log("Manette");
            transform.position = new Vector3(transform.position.x + Input.GetAxis("RightHorizontal") * camSpeed, transform.position.y + Input.GetAxis("RightVertical") * camSpeed, transform.position.z);
        }        
        if(Gamepad.current == null)
        {
            //Debug.Log("Souris");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = mousePosition;
        }
    }

}
