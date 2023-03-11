using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoneyInfo : IinfoContainer
{
    public int Money;

    public void ChangeMoney(int difference)
    {
        Money += difference;
    }

    public int Debt;

    public void LoadInfo()
    {
        Money = 1000;
        Debt = 10000;
    }
}
