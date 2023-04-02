using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    static bool[] checkpointTab = new bool[3];   // Un tableau de valeurs bool�ennes pour stocker les �tats des points de contr�le.

    void Update() // Cette m�thode est appel�e � chaque image.
    {
        Debug.Log(checkpointTab[0] + " " + checkpointTab[1] + " " + checkpointTab[2]);

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
        if (CheckPointName == "CheckPoint_01") CheckPoint_01();
        if (CheckPointName == "CheckPoint_02") CheckPoint_02();
        if (CheckPointName == "CheckPoint_03") CheckPoint_03();
    }

    public bool GetCheckPointState(string CheckPointName)
    {
        // Cette m�thode est appel�e pour obtenir l'�tat d'un point de contr�le en fonction de son nom.
        if (CheckPointName == "CheckPoint_01") return checkpointTab[0];
        if (CheckPointName == "CheckPoint_02") return checkpointTab[1];
        if (CheckPointName == "CheckPoint_03") return checkpointTab[2];
        else return false;
    }

    void CheckPoint_01()
    {
        checkpointTab[0] = true;
    }

    void CheckPoint_02()
    {
        checkpointTab[1] = true;
    }

    void CheckPoint_03()
    {
        checkpointTab[2] = true;
    }
}
