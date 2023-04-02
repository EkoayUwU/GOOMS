using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] spawnManager spawnManager;
    Vector3 refVelocity = Vector3.zero;
    float smoothTime = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnManager.GetSpawnPosition() + new Vector3 (0f, 5f, 0) ;
    }

    // Update is called once per frame
    void Update()
    {
        //Modifie pos cam�ra en fonction des pos du joueurz
        Vector3 targetPosition = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y + 5f, -10);
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref refVelocity, smoothTime);
    }

}