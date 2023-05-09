using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    static Vector3 spawnPosition = new Vector3 (-360,-22,-4.5f);

    void Start()
    {
        transform.position = spawnPosition; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("LD_OVERVIEW");
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
