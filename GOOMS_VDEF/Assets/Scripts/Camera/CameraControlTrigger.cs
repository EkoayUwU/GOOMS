using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControlTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraOnLeft;
    [SerializeField]  CinemachineVirtualCamera cameraOnRight;

    private Collider2D _coll;

    private void Start()
    {
        _coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector2 exitDirection = (collision.transform.position - _coll.bounds.center).normalized;

            //swap Camera
            CameraManager.instance.SwapCamera(cameraOnLeft, cameraOnRight, exitDirection);
        }
    }
}
