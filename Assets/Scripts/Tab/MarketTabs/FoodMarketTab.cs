using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMarketTab : Tab
{
    [SerializeField] private RectTransform scrollViewTransform;
    [SerializeField] private GameObject marketItemPref;
    [SerializeField] private Text priceText;

    private int _currentPrice = 0;

    public int CurrentPrice
    {
        set 
        { 
            _currentPrice = value;
            priceText.text = $"Итого: {_currentPrice}";
        }
        get { return _currentPrice; }
    }

    private List<Item> _itemsForPurchasinng;
    private List<int> _numbersOfItemsForPurchasing;

    public void AddNewItemForPurchasing(Item item)
    {
        CurrentPrice += item.Price;
        if (_itemsForPurchasinng.Contains(item))
        {
            _numbersOfItemsForPurchasing[_itemsForPurchasinng.IndexOf(item)]++;
        }
        else
        {
            _itemsForPurchasinng.Add(item);
            _numbersOfItemsForPurchasing.Add(1);
        }
    }

    public void RemoveItemForPurchasing(Item item)
    {
        if (_itemsForPurchasinng.Contains(item))
        {
            int index = _itemsForPurchasinng.IndexOf(item);
            if (_numbersOfItemsForPurchasing[index] > 1)
            {
                _numbersOfItemsForPurchasing[index] -= 1;
            }
            else
            {
                _numbersOfItemsForPurchasing.RemoveAt(index);
                _itemsForPurchasinng.RemoveAt(index);
            }
            CurrentPrice -= item.Price;
        }
    }

    public override void OpenTab()
    {
        while(scrollViewTransform.childCount > 0)
        {
            Destroy(scrollViewTransform.GetChild(0).gameObject);
        }
        foreach(var mealComponent in SingletoneInfoContainer.MealComponents)
        {
            GameObject newItem = Instantiate(marketItemPref, scrollViewTransform);
            int currentNumberInStorage = SingletoneInfoContainer.Storage.
                ComponentsInStorageNumbers[SingletoneInfoContainer.Storage.ComponentsInStorage.IndexOf(mealComponent)];
            newItem.GetComponent<MarketItem>().SetUpItem(currentNumberInStorage, mealComponent, this);
        }
        _itemsForPurchasinng = new List<Item>();
        _numbersOfItemsForPurchasing = new List<int>();
        CurrentPrice = 0;
        base.OpenTab();
    }

    public void Buy()
    {
        
        if (SingletoneInfoContainer.MoneyInfo.Money >= _currentPrice)
        {
            SingletoneInfoContainer.MoneyInfo.Money -= _currentPrice;
            SingletoneInfoContainer.Storage.AddMealComponents(_itemsForPurchasinng, _numbersOfItemsForPurchasing);
        }
        else
            NotEnoughMoney();
    }

    public void Back()
    {

    }

    private void NotEnoughMoney()
    {

    }
}
