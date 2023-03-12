using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropValidItem : MonoBehaviour
{
    private Collider2D _collider;
    public bool Triggered = false;
    private DragController _dragController;
    public List<GameObject> AttachedItems;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    public void Attach(GameObject g)
    {
        AttachedItems.Add(g);
    }

    public void Deattach(GameObject g)
    {
        for(int i = 0; i < AttachedItems.Count; ++i)
        {
            if (g.name == AttachedItems[i].name)
            {
                AttachedItems.RemoveAt(i);
            }
        }
    }
}
