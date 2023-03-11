using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketItem : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private Text CountText;
    private FoodMarketTab _foodMarketTab;
    private Item _item;

    public Item Item { get { return _item; } }

    public void SetUpItem(int currentNumber, Item item, FoodMarketTab foodMarketTab)
    {
        Icon.sprite = item.Icon;
        CountText.text = $"{currentNumber}/{item.MaxNumber}";
        _foodMarketTab= foodMarketTab;
    }

    public void Plus()
    {
        _foodMarketTab.AddNewItemForPurchasing(this._item);
    }
}
