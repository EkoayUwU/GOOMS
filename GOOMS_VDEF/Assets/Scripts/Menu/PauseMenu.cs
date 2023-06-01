using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    

    bool isGamePaused;

    [SerializeField] GameObject pauseMenuRef;
    [SerializeField] GameObject fondRef;

    private void Start()
    {
        isGamePaused = false;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel")))
        {
            if (isGamePaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {      
        pauseMenuRef.SetActive(false);
        fondRef.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        
    }
    void Pause()
    {
        pauseMenuRef.SetActive(true);
        fondRef.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Leave()
    {
        Application.Quit();
    }
}
