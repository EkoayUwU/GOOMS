using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _PlayerRef;
    private void Update()
    {
        transform.position = new Vector3(_PlayerRef.position.x, transform.position.y, transform.position.z);
    }
}
