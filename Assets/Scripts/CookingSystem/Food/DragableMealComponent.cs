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
        NullSprite();
    }

    public void NullSprite()
    {
        ChangeSprite(null);
    }

    public void DragSprite()
    {
        ChangeSprite(Comp.Icon);
    }

    public void BoardSprite()
    {
        ChangeSprite(Comp.Sprite);
    }

    private void ChangeSprite(Sprite s)
    {
        GetComponent<SpriteRenderer>().sprite = s;
    }
}
