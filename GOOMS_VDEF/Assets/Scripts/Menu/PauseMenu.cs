using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    

    bool isGamePaused;

    [SerializeField] GameObject pauseMenuRef;
    [SerializeField] GameObject optionsMenuRef;
    [SerializeField] GameObject EventSystemePause;
    [SerializeField] GameObject EventSystemeOptions;
    [SerializeField] GameObject fondRef;

    private void Start()
    {
        isGamePaused = false;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel")))
        {
            if (isGamePaused)
            {
                Resume();
            }          
            else Pause();

            if (optionsMenuRef.active)
            {
                optionsMenuRef.SetActive(false);
                EventSystemePause.SetActive(true);
                EventSystemeOptions.SetActive(false);
            }
        }
    }

    public void Resume()
    {      
        pauseMenuRef.SetActive(false);
        fondRef.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        GameObject.Find("Cursor").GetComponent<SpriteRenderer>().enabled = true;
    }
    void Pause()
    {
        pauseMenuRef.SetActive(true);
        fondRef.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = false;
        GameObject.Find("Cursor").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Leave()
    {
        Application.Quit();
    }
}
