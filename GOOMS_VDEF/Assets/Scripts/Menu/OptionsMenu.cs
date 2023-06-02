using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    static float cursorSpeedOptions = 0.3f;

    private void Start()
    {
        

        if ( GameObject.Find("Cursor") != null)
        {
            GameObject.Find("Cursor").GetComponent<CursorPosition>().SetCursorSpeed(cursorSpeedOptions);
        }
    }

    public void SetSentivity(float sensitivityValue)
    {
        cursorSpeedOptions = sensitivityValue / 10;

        if (GameObject.Find("Cursor") != null) GameObject.Find("Cursor").GetComponent<CursorPosition>().SetCursorSpeed(cursorSpeedOptions);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
