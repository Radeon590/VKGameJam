using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableMealComponent : MonoBehaviour
{
    public MealComponent Comp;
    public MealComponent CompOnBoard;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Comp.Sprite;
    }
}