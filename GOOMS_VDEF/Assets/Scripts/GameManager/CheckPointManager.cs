using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] GameObject[] NameCheckpointTab;

    static bool[] checkpointTab;   // Un tableau de valeurs bool�ennes pour stocker les �tats des points de contr�le.

    bool checkpointState;




    private void Start()
    {
        //checkpointTab = checkpointTab == null ? new bool[NameCheckpointTab.Length] : checkpointTab;

        checkpointTab = new bool[NameCheckpointTab.Length];
        for (int i = 0; i < NameCheckpointTab.Length; i++)
        {
            checkpointTab[i] = false;
        }
    }

    void Update()
    {
        // Cette boucle v�rifie si un point de contr�le a �t� atteint.
        for (int i = 0; i < checkpointTab.Length; i++)
        {
            if (checkpointTab[i] == true)
            {
                // Si un point de contr�le a �t� atteint, il d�finit tous les points de contr�le pr�c�dents comme atteints �galement.
                for (int j = 0; j < i; j++)
                {
                    checkpointTab[j] = true;
                }
            }
        }

        //Debug
        //for(int i = 0; i < checkpointTab.Length; i++)
        //{
        //    Debug.Log("CheckPoint " + i + " " + checkpointTab[i]);
        //}

        
    }

    public void SetCheckPoint(string CheckPointName)
    {


        for (int i = 0; i < checkpointTab.Length; i++)
        {
 
            if (CheckPointName == NameCheckpointTab[i].name) 
            {

                CheckPoint(i);             
            }
            

        }
    }

    public bool GetCheckPointState(string CheckPointName)
    {

        
        for (int i = 0; i < checkpointTab.Length; i++)
        {
            
            if (CheckPointName == NameCheckpointTab[i].name)
            {
                checkpointState = checkpointTab[i];
            }           
        }
        return checkpointState;
    }

    void CheckPoint(int i)
    {
        checkpointTab[i] = true;
    }

    public void ResetCheckPointTab()
    {
        for (int i = 0; i < checkpointTab.Length; i++) checkpointTab[i] = false;
    }
   
}
