using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{

    void Start()
    {
        Application.targetFrameRate = 60;
    }

}
