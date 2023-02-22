using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveSystem : MonoBehaviour
{
    [SerializeField] LogicGateValve LogicGateValve;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            LogicGateValve.Set(gameObject.name);
        }

        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "MouseController" && Input.GetMouseButtonDown(0))
        {
            LogicGateValve.Set(gameObject.name);
        }
        Debug.Log("Contacte");
    }

}
