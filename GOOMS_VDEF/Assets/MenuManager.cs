using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button OptionsButton;
    [SerializeField] Button LeaveButton;

    private void Start()
    {
        Debug.Log(StartButton);
        Debug.Log(OptionsButton);
        Debug.Log(LeaveButton);
    }
}
