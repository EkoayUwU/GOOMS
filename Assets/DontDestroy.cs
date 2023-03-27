using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] GameObject[] savedObjects;
    
    private void Awake()
    {
        foreach (var element in savedObjects)
        {
            DontDestroyOnLoad(element);
        }
        
    }
}
