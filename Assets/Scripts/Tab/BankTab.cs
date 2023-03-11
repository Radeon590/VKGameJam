using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankTab : Tab
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text debtText;

    public override void OpenTab()
    {
        UpdateTab();
        base.OpenTab();
    }

    public void PayDebt()
    {
        SingletoneInfoContainer.MoneyInfo.Debt -= SingletoneInfoContainer.MoneyInfo.Money;
        SingletoneInfoContainer.MoneyInfo.Money = 0;
        UpdateTab();
    }

    public void TakeDebt()
    {
        SingletoneInfoContainer.MoneyInfo.Debt += 10000;
        SingletoneInfoContainer.MoneyInfo.Money += 10000;
        UpdateTab();
    }

    private void UpdateTab()
    {
        moneyText.text = $"{SingletoneInfoContainer.MoneyInfo.Money}";
        debtText.text = $"{SingletoneInfoContainer.MoneyInfo.Debt}";
    }
}
