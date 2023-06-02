using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPosition : MonoBehaviour
{
    [SerializeField] GameObject cameraRef;
    static float cursorSpeed;
    
    [SerializeField] GameObject playerRef;
    float OffsetRadius;

    [SerializeField] GameObject[] PropsList;
    GameObject PropsRef;

    private void Start()
    {
        OffsetRadius = 2.25f;
    }

    void Update()
    {
        float tailleCam = cameraRef.GetComponent<Camera>().orthographicSize;

        //Encadrement Curseur
        if (transform.position.x < cameraRef.transform.position.x - tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x - tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.x > cameraRef.transform.position.x + tailleCam * 1.75) transform.position = new Vector3(cameraRef.transform.position.x + tailleCam * 1.75f, transform.position.y, transform.position.z);
        if (transform.position.y < cameraRef.transform.position.y - tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y - tailleCam, transform.position.z);
        if (transform.position.y > cameraRef.transform.position.y + tailleCam) transform.position = new Vector3(transform.position.x, cameraRef.transform.position.y + tailleCam, transform.position.z);

        //Manette
        if (Gamepad.current != null)
        {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("RightHorizontal") * cursorSpeed * Time.deltaTime * 55, transform.position.y + Input.GetAxis("RightVertical") * cursorSpeed * Time.deltaTime * 55, transform.position.z);

            //if (grabReach.GetOnReach()) transform.position = grabReach.GetProps().transform.position;

            PropsRef = IsInRange();

            if (PropsRef != null && Input.GetAxis("RT") == 0)
            {
                transform.position = new Vector3(PropsRef.transform.position.x, PropsRef.transform.position.y, transform.position.z);
            }
        }     
        
        //Souris
        if(Gamepad.current == null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = mousePosition;

            //if (grabReach.GetOnReach()) transform.position = grabReach.GetProps().transform.position;

            PropsRef = IsInRange();

            if (PropsRef != null && !Input.GetMouseButtonDown(0))
            {
                transform.position = new Vector3(PropsRef.transform.position.x, PropsRef.transform.position.y, transform.position.z);
            }
        }
        
        PropsList = GameObject.FindGameObjectsWithTag("staticProps");

        print(cursorSpeed);
    }

    GameObject IsInRange()
    {
        foreach (var Props in PropsList)
        {
            if(CheckLeftAbscisse(Props) && CheckRightAbscisse(Props) && CheckUpperPoint(Props) && CheckLowerPoint(Props))
            {
                return Props;
            }
        }
        return null;
    }

    
    bool CheckLeftAbscisse(GameObject Props)
    {
        //Debug.Log("Left " + (Props.transform.position.x > (playerRef.transform.position.x - OffsetRadius) ? true : false));
        return Props.transform.position.x > (playerRef.transform.position.x - OffsetRadius) ? true : false;
        
    }
    bool CheckRightAbscisse(GameObject Props)
    {
        //Debug.Log("Right " + (Props.transform.position.x < (playerRef.transform.position.x + OffsetRadius) ? true : false));
        return Props.transform.position.x < (playerRef.transform.position.x + OffsetRadius) ? true : false;
    }
    bool CheckUpperPoint(GameObject Props)
    {
        //Debug.Log("Up " + (Props.transform.position.y < (playerRef.transform.position.y + OffsetRadius) ? true : false));
        return Props.transform.position.y < (playerRef.transform.position.y + OffsetRadius) ? true : false;
    }
    bool CheckLowerPoint(GameObject Props)
    {
        //Debug.Log("Down " + (Props.transform.position.y > (playerRef.transform.position.y - OffsetRadius) ? true : false));
        return Props.transform.position.y > (playerRef.transform.position.y - OffsetRadius) ? true : false;
    }

    public void SetCursorSpeed(float newValue)
    {
        cursorSpeed = newValue;

        print("fnct " +cursorSpeed);
    }
}
