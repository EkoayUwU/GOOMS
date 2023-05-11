using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    static Vector2 spawnPosition = Vector2.zero;

    void Start()
    {
        transform.position = spawnPosition; 
    }

    private void Update()
    {
        string actualScene = "" + SceneManager.GetActiveScene().name;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void SetSpawnPosition(Vector2 Position)
    {
        spawnPosition = Position;
    }  

    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }
}
