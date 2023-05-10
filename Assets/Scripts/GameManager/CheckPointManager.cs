using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] GameObject[] NameCheckpointTab;
    static bool[] checkpointTab;   // Un tableau de valeurs bool�ennes pour stocker les �tats des points de contr�le.
    bool checkpointState;


    private void Start()
    {
        checkpointTab = new bool[NameCheckpointTab.Length];
        Debug.Log(checkpointTab.Length);
    }

    void Update()
    {
        for (int i = 0; i < checkpointTab.Length; i++)
        {
            Debug.Log(checkpointTab[i] + " " + i);
            
        }
        
        //Debug.Log(checkpointTab[0] + " " + checkpointTab[1] + " " + checkpointTab[2]);

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

        
        
    }

    public void SetCheckPoint(string CheckPointName)
    {
        // Cette m�thode est appel�e pour d�finir un point de contr�le comme atteint en fonction de son nom.
        //if (CheckPointName == "CheckPoint_01") CheckPoint_01();
        //if (CheckPointName == "CheckPoint_02") CheckPoint_02();
        //if (CheckPointName == "CheckPoint_03") CheckPoint_03();

        for (int i = 0; i > checkpointTab.Length; i++)
        {
            Debug.Log("test");
            Debug.Log(CheckPointName);
            Debug.Log(NameCheckpointTab[i].name);
            if (CheckPointName == NameCheckpointTab[i].name) 
            {   
                CheckPoint(i);             
            }
            

        }
    }

    public bool GetCheckPointState(string CheckPointName)
    {
        // Cette m�thode est appel�e pour obtenir l'�tat d'un point de contr�le en fonction de son nom.
        //if (CheckPointName == "CheckPoint_01") return checkpointTab[0];
        //if (CheckPointName == "CheckPoint_02") return checkpointTab[1];
        //if (CheckPointName == "CheckPoint_03") return checkpointTab[2];
        //else return false;
        
        for (int i = 0; i > checkpointTab.Length; i++)
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
    //void CheckPoint_01()
    //{
    //    checkpointTab[0] = true;
    //}

    //void CheckPoint_02()
    //{
    //    checkpointTab[1] = true;
    //}

    //void CheckPoint_03()
    //{
    //    checkpointTab[2] = true;
    //}
}
