using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] GameObject[] NameCheckpointTab;
    static bool[] checkpointTab;   // Un tableau de valeurs booléennes pour stocker les états des points de contrôle.
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

        // Cette boucle vérifie si un point de contrôle a été atteint.
        for (int i = 0; i < checkpointTab.Length; i++)
        {
            if (checkpointTab[i] == true)
            {
                // Si un point de contrôle a été atteint, il définit tous les points de contrôle précédents comme atteints également.
                for (int j = 0; j < i; j++)
                {
                    checkpointTab[j] = true;
                }
            }
        }

        
        
    }

    public void SetCheckPoint(string CheckPointName)
    {
        // Cette méthode est appelée pour définir un point de contrôle comme atteint en fonction de son nom.
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
        // Cette méthode est appelée pour obtenir l'état d'un point de contrôle en fonction de son nom.
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
