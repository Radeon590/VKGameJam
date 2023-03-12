using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPoint : MonoBehaviour
{
    [SerializeField] private Controller cookingController;

    public void StartCooking()
    {
        cookingController.Activate();
    }
}
