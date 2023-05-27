using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LogicGate : MonoBehaviour
{

    [SerializeField] GameObject doorRef;

    [SerializeField] Light2D[] LightRefList;
    [SerializeField] GameObject[] GameObjectLightList;
    [SerializeField] Sprite[] SpriteList;

    [SerializeField] bool[] logicGates = new bool[4];



    private bool isOpen = false;



    void Update()
    {
        
        //Ouvre Porte si toute les lights sont allumées

        isOpen = logicGates[0] && logicGates[1] && logicGates[2] && logicGates[3] ? true : false;

        //Set la couleur des lights
        for (int i = 0; i < logicGates.Length; i++)
        {
            GameObjectLightList[i].GetComponent<SpriteRenderer>().sprite = (LightRefList[i].color = logicGates[i] ? Color.green : Color.yellow) == Color.green ? SpriteList[1] : SpriteList[0];
        }

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
    }

    //Valve 3
    private void Valve3()
    {
        logicGates[0] = !logicGates[0];
        logicGates[2] = !logicGates[2];
    }

    //Valve 4
    private void Valve4()
    {
        logicGates[1] = !logicGates[1];
        logicGates[2] = !logicGates[2];
    }

    //Set
    public void Set(string ValveInfo)
    {
        if (ValveInfo == "Valve1") Valve1();
        if (ValveInfo == "Valve2") Valve2();
        if (ValveInfo == "Valve3") Valve3();
        if (ValveInfo == "Valve4") Valve4();
    }

}