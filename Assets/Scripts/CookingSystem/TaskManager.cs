using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Meal> MealsTask = new List<Meal>();

    public void SubmitTask()
    {
        Inventory inventory = GetComponent<Inventory>();
        if (inventory.ItemInHand != null && inventory.ItemInHand is Meal)
        {
            if (IsItRequiredMeal(inventory.ItemInHand as Meal))
            {
                
            }
            else
                ShowErrorScreen();
            inventory.ItemInHand = null;
            return;
        }
        ShowErrorScreen();
    }

    private bool IsItRequiredMeal(Meal mealToCheck)
    {
        foreach (var meal in MealsTask)
        {
            if (mealToCheck == meal)
                return true;
        }
        return false;
    }

    private void ShowErrorScreen()
    {

    }
}
