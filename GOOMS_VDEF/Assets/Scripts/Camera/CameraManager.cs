using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    //Array Camera
    [SerializeField] CinemachineVirtualCamera[] VirtualCamerasList;
    //Ref Camera Active
    [SerializeField] CinemachineVirtualCamera _CurrentCamera;

    CinemachineFramingTransposer _framingTransposer;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Ref current active camera
        for(int i = 0; i < VirtualCamerasList.Length; i++)
        {
            if (VirtualCamerasList[i].enabled)
            {
                _CurrentCamera = VirtualCamerasList[i];
                _framingTransposer = _CurrentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }
    }

    #region Swap Camera

    public void SwapCamera(CinemachineVirtualCamera cameraFromLeft, CinemachineVirtualCamera cameraFromRight, Vector2 triggerExitDirection)
    {
        //if current camera is left camera and player exit on right
        if( _CurrentCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            //Activate new camera
            cameraFromRight.enabled = true;
            //Disable old camera
            cameraFromLeft.enabled = false;
            //Set new camera to the reference
            _CurrentCamera = cameraFromRight;

            _framingTransposer = _CurrentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

        //if current camera is right camera and player exit on left
        else if (_CurrentCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            //Activate new camera
            cameraFromLeft.enabled = true;
            //Disable old camera
            cameraFromRight.enabled = false;         
            //Set new camera to the reference
            _CurrentCamera = cameraFromLeft;

            _framingTransposer = _CurrentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
    }

    #endregion
}
