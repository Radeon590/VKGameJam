using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField] private Transform littleRecipeGroup;
    [SerializeField] private Transform bigRecipeGroup;
    [SerializeField] private GameObject linePref;
    

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
        littleRecipeGroup.gameObject.SetActive(true);
        bigRecipeGroup.gameObject.SetActive(false);
    }

    public void ShowFullRecipe()
    {
        littleRecipeGroup.gameObject.SetActive(false);
        bigRecipeGroup.gameObject.SetActive(true);
    }
}
