using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] spawnManager spawnManager;
    [SerializeField] CheckPointManager CheckPointManager;

    [SerializeField] CinemachineVirtualCamera UsedCameraRef;

    CameraManager cmRef;

    private void Start()
    {
        //Ref CameraManager
        cmRef = GameObject.Find("Cameras").GetComponent<CameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Set les pos de spawn du joueur selon le checkpoint et modifie létat du checkpoint dans le tableau 
            spawnManager.SetSpawnPosition(transform.position);
            CheckPointManager.SetCheckPoint(gameObject.name);

            //Debug.Log("CHECKPOINT");

            //Set la cam en fonction du checkpoint sur lequel le player respawn
            cmRef._CurrentCamera.enabled = false;
            cmRef._CurrentCamera = UsedCameraRef;
            cmRef._CurrentCamera.enabled = true;

        }
    }

    private void Update()
    {
        //Désactive tous les checkpoints se trouvant avant le dernier checkpoint activé
        if (CheckPointManager.GetCheckPointState(gameObject.name))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
