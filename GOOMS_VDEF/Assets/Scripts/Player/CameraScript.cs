using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject playerRef;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = playerRef.transform.position + new Vector3(0,4.25f,-10);
    }
}
