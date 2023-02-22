using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGateValve : MonoBehaviour
{
    [SerializeField] SpriteRenderer lightRef1;
    [SerializeField] SpriteRenderer lightRef2;
    [SerializeField] SpriteRenderer lightRef3;

    [SerializeField] GameObject doorRef;
    [SerializeField] bool[] logicGates = new bool[3];

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightRef1.color = logicGates[0] ? Color.yellow : Color.black;
        lightRef2.color = logicGates[1] ? Color.yellow : Color.black;
        lightRef3.color = logicGates[2] ? Color.yellow : Color.black;

        isOpen = logicGates[0] & logicGates[1] & logicGates[2]? true : false;

        doorRef.SetActive(!isOpen);


    }

    //Valve 1

    private void Valve1()
    {
        logicGates[0] = !logicGates[0];
        logicGates[2] = !logicGates[2];
    }

    private void Valve2()
    {
        logicGates[1] = !logicGates[1];
        logicGates[2] = !logicGates[2];
    }

    private void Valve3()
    {
        logicGates[0] = !logicGates[0];
        logicGates[1] = !logicGates[1];
    }

    public void Set(string ValveInfo)
    {
        if (ValveInfo == "Valve 1") Valve1();
        if (ValveInfo == "Valve 2") Valve2();
        if (ValveInfo == "Valve 3") Valve3();
        Debug.Log(ValveInfo);
    }

}
