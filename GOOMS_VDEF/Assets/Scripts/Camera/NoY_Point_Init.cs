using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoY_Point_Init : MonoBehaviour
{
    [SerializeField] GameObject NoY_Point;
    [SerializeField] float NoY_Height;

    private void OnTriggerExit2D(Collider2D collision)
    {
        NoY_Point.transform.position = new Vector3(NoY_Point.transform.position.x, NoY_Height, NoY_Point.transform.position.z);
    }
}
