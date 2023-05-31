using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    //[SerializeField] GameObject PauseMenuRef;
    //[SerializeField] GameObject FondRef;

    //bool isOpen;
    //bool isTimed;

    //void Start()
    //{
    //    isOpen = false;
    //    isTimed = false;
    //}

    //private void Update()
    //{
    //    if (!isTimed && (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel")) )
    //    {
    //        OpenMenu();
    //    }

    //}

    //void OpenMenu()
    //{
    //    isOpen = !isOpen;

    //    SetMenu(isOpen);
    //}

    //void SetMenu(bool isSet)
    //{
    //    PauseMenuRef.SetActive(isSet);
    //    FondRef.SetActive(isSet);

    //    StartCoroutine(Timer());
    //}

    //IEnumerator Timer()
    //{
    //    isTimed = true;
    //    yield return new WaitForSeconds(0.25f);
    //    isTimed = false;
    //}


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
