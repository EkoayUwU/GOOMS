using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform PlayerRef;
    private void Awake()
    {
        PlayerRef.position = transform.position;
    }
}
