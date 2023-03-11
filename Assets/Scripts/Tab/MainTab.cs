using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTab : Tab
{
    [SerializeField] private FoodMarketTab marketTab;
    [SerializeField] private BankTab bankTab;

    public void OpenMarket()
    {
        marketTab.OpenTab();
    }

    public void OpenBank()
    {
        bankTab.OpenTab();
    }
}
