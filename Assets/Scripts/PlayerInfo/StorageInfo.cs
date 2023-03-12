using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StorageInfo: IinfoContainer
{
    public List<MealComponent> ComponentsInStorage;
    public List<int> ComponentsInStorageNumbers;

    public void AddMealComponents(List<Item> items, List<int> numbers)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (ComponentsInStorage.Contains(items[i] as MealComponent))
            {
                ComponentsInStorageNumbers[ComponentsInStorage.IndexOf(items[i] as MealComponent)] += numbers[i];
            }
            else
            {
                ComponentsInStorage.Add(items[i] as MealComponent);
                ComponentsInStorageNumbers.Add(numbers[i]);
            }
        }
    }

    public void LoadInfo()
    {
        ComponentsInStorage = new List<MealComponent>();
        ComponentsInStorageNumbers = new List<int>();
        //testing
        ComponentsInStorage = SingletoneInfoContainer.MealComponents;
        for(int i = 0; i < ComponentsInStorage.Count; i++)
        {
            ComponentsInStorageNumbers.Add(100);
        }
    }
}
