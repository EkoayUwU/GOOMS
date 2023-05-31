using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public float cursorSpeed;

    public void SetSentivity(float sensitivityValue)
    {
        cursorSpeed = sensitivityValue / 10;
        Debug.Log(cursorSpeed);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
