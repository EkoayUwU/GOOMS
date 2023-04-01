using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int coinsCount;
    void Start()
    {
        //Init le nbr de coins
        coinsCount = 0;
    }

    public void SetCoins(int value)
    {
        //Attribu le nbr de coins
        coinsCount += value;
    }

    public int GetCoins()
    {
        //Renvoie le nbr de coins
        return coinsCount;
    }
}
