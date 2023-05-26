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

    public void SetSpawnPosition(Vector2 Position)
    {
        spawnPosition = Position;
    }  

    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }

    public void ReloadSceneOnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
