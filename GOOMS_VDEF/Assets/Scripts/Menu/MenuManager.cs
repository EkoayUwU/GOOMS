using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TUTO_LEVEL");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    
}
