using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(TaskView), typeof(Inventory))]
public class TaskController : MonoBehaviour
{
    [SerializeField] private TaskView taskView;
    [SerializeField] private TaskPoint taskPoint;

    private List<Meal> _taskMeals;

    public List<Meal> TaskMeals
    {
        get { return _taskMeals; }
        set
        {
            _taskMeals = value;
        }
    }

    public void AcceptTask()
    {
        _taskMeals = taskPoint.ConsumerInPoint.Consumer.Wishes;
    }

    public void SubmitTask()
    {
        Inventory inventory = GetComponent<Inventory>();
        if (inventory.ItemInHand != null && inventory.ItemInHand is Meal)
        {
            if (IsOrderContainsMeal(inventory.ItemInHand as Meal))
            {
                _taskMeals.Remove(inventory.ItemInHand as Meal);
                taskPoint.ConsumerInPoint.ShowEmoje(EmojiTypes.Glad);
            }
            else
            {
                ShowErrorScreen();
            }
            inventory.ItemInHand = null;
            return;
        }
        ShowErrorScreen();
    }

    private bool IsOrderContainsMeal(Meal meal)
    {
        foreach(var mealToCompare in _taskMeals)
        {
            if (mealToCompare.Equals(meal))
            {
                return true;
            }
        }
        return false;
    }

    private void ShowErrorScreen()
    {
        taskPoint.ConsumerInPoint.ShowEmoje(EmojiTypes.Upset);
    }
}
