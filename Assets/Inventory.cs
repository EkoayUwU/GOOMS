using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int coinsCount;
    void Start()
    {
        coinsCount = 0;
    }

    public void SetCoins(int value)
    {
        coinsCount += value;
    }

    public int GetCoins()
    {
        return coinsCount;
    }
}
