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

    public static StorageInfo Storage;

    public static MoneyInfo MoneyInfo;

    public static CafeInfo CafeInfo;

    public void LoadInfo()
    {
        s_mealComponents = mealComponents;
        Storage = new StorageInfo();
        Storage.LoadInfo();
        MoneyInfo = new MoneyInfo();
        MoneyInfo.LoadInfo();
        CafeInfo = new CafeInfo();
        CafeInfo.LoadInfo();
    }
}
