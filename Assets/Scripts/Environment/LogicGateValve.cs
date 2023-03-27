using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGateValve : MonoBehaviour
{
    [SerializeField] SpriteRenderer lightRef1;
    [SerializeField] SpriteRenderer lightRef2;
    [SerializeField] SpriteRenderer lightRef3;
    [SerializeField] SpriteRenderer lightRef4;
    [SerializeField] SpriteRenderer lightRef5;

    [SerializeField] GameObject doorRef;
    [SerializeField] bool[] logicGates = new bool[5];

    private bool isOpen = false;

    void Update()
    {
        //Set la couleur des lights

        lightRef1.color = logicGates[0] ? Color.yellow : Color.black;
        lightRef2.color = logicGates[1] ? Color.yellow : Color.black;
        lightRef3.color = logicGates[2] ? Color.yellow : Color.black;
        lightRef4.color = logicGates[3] ? Color.yellow : Color.black;
        lightRef5.color = logicGates[4] ? Color.yellow : Color.black;

        //Ouvre Porte si toute les lights sont allumées

        isOpen = logicGates[0] & logicGates[1] & logicGates[2] & logicGates[3] & logicGates[4] ? true : false;

        doorRef.SetActive(!isOpen);


    }

    //Valve 1

    private void Valve1()
    {
        logicGates[0] = !logicGates[0];
        logicGates[1] = !logicGates[1];
    }

    //Valve 2
    private void Valve2()
    {
        logicGates[3] = !logicGates[3];
        logicGates[4] = !logicGates[4];
    }

    //Valve 3
    private void Valve3()
    {       
        logicGates[2] = !logicGates[2];
    }

    //Set
    public void Set(string ValveInfo)
    {
        if (ValveInfo == "Valve 1") Valve1();
        if (ValveInfo == "Valve 2") Valve2();
        if (ValveInfo == "Valve 3") Valve3();

    }

}
