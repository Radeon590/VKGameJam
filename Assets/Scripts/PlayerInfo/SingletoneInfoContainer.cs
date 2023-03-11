using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneInfoContainer : MonoBehaviour, IinfoContainer
{
    [SerializeField] private List<MealComponent> mealComponents= new List<MealComponent>();

    private static List<MealComponent> s_mealComponents;

    public static List<MealComponent> MealComponents
    {
        get { return s_mealComponents; }
    }

    private static StorageInfo s_storage;

    public static StorageInfo Storage
    {
        get { return s_storage; }
    }

    private static MoneyInfo s_moneyInfo;

    public static MoneyInfo MoneyInfo
    {
        get { return s_moneyInfo; }
    }

    public void LoadInfo()
    {
        s_storage = new StorageInfo();
        s_storage.LoadInfo();
        s_moneyInfo= new MoneyInfo();
        s_moneyInfo.LoadInfo();
        s_mealComponents = mealComponents;
    }
}
