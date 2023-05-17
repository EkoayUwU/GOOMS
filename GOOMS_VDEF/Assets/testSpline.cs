using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpline : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;
    [SerializeField] Transform pointD;

    float InterpolateTime;

    private void Update()
    {
        InterpolateTime = (InterpolateTime + Time.deltaTime) % 1f;

        /*
        pointAB.position = Vector3.Lerp(pointA.position, pointB.position, InterpolateTime);
        pointBC.position = Vector3.Lerp(pointB.position, pointC.position, InterpolateTime);
        pointCD.position = Vector3.Lerp(pointC.position, pointD.position, InterpolateTime);

        pointAB_BC.position = Vector3.Lerp(pointAB.position, pointBC.position, InterpolateTime);
        pointBC_CD.position = Vector3.Lerp(pointBC.position, pointCD.position, InterpolateTime);
        */

        transform.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, InterpolateTime);
    }
    
    Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, InterpolateTime);
    }

    Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, InterpolateTime);
    }
}
