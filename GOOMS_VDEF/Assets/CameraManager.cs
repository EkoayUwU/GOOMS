using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform playerRef;
    CinemachineFramingTransposer CMFT;

    private void Start()
    {
        CMFT = GetComponentInChildren<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        CMFT.m_TrackedObjectOffset = playerRef.localScale.x == 1 ? new Vector3(1, 0, 0) : new Vector3(-1, 0, 0);
    }
}