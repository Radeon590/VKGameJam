using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMeal", menuName = "ScriptableObjects/CookingSystem/Meal")]
public class Meal : Food
{
    public List<MealComponent> MealComponents;
}
