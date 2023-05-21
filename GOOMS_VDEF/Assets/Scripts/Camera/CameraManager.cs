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

    //Lerp Y Damping Variables
    bool isLerpYDamping;

    float _fallPanAmount = 0.25f;
    float _fallYPanTime = 0.35f;
    public float _fallSpeedYDampingChangeThreshold = 15f;
    float _normYPanAmount;

    public bool isLerpingYDamping { get; private set; }
    public bool LerpedFromPlayerFalling { get; set; }

    

    //Avoir un seule cam manager d'actif
    void Awake()
    {
        if (instance == null) instance = this;
    }


    void Update()
    {
        //Ref current active camera
        for(int i = 0; i < VirtualCamerasList.Length; i++)
        {
            if (VirtualCamerasList[i].enabled)
            {
                //Set current Camera
                _CurrentCamera = VirtualCamerasList[i];
                _framingTransposer = _CurrentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }
    }

    #region Lerp Y Damping
    public void LerpYDamping(bool isPlayerFalling)
    {
        StartCoroutine(LerpYAction(isPlayerFalling));
    }

    IEnumerator LerpYAction(bool isPlayerFalling)
    {
        isLerpYDamping = true;

        //Grab start damping amount
        float startDampAmount = _framingTransposer.m_YDamping;
        float endDampAmount = 0f;

        //determine end damping amount
        if (isPlayerFalling)
        {
            endDampAmount = _fallPanAmount;
            LerpedFromPlayerFalling = true;
        }
        else endDampAmount = _normYPanAmount;


        //lerp pan amount
        float elapsedTime = 0f;
        while (elapsedTime < _fallPanAmount)
        {
            elapsedTime += Time.deltaTime;

            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elapsedTime / _fallPanAmount));
            _framingTransposer.m_YDamping = lerpedPanAmount;

            yield return null;
        }

        isLerpYDamping = false;
    }
    #endregion

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
