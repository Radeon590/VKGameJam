using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField] private Transform littleRecipeGroup;
    [SerializeField] private Transform bigRecipeGroup;
    

    private List<Meal> _orderList = new List<Meal>();

    public List<Meal> OrderList
    {
        set 
        { 
            _orderList = value; 
            ShowLittleRecipe();
        }
    }

    public void ShowLittleRecipe()
    {

    }

    public void ShowFullRecipe()
    {

    }
}
