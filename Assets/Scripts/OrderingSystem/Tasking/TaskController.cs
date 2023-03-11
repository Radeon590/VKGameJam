using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public List<Meal> _taskMeals;

    public List<Meal> TaskMeals
    {
        get { return _taskMeals; }
        set
        {
            _taskMeals = value;
        }
    }

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
        foreach (var meal in TaskMeals)
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
