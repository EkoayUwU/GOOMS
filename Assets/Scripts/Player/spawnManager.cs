using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    static Vector3 spawnPosition = new Vector3 (-40,0,0);

    void Start()
    {
        transform.position = spawnPosition; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SceneSandboxTest");
        }
    }
    public void SetSpawnPosition(Vector3 Position)
    {
        spawnPosition = Position;
    }  

    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }
}
