using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropValidItem : MonoBehaviour
{
    private Collider2D _collider;
    public bool Triggered = false;
    private DragController _dragController;
    public List<GameObject> AtachedItems;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Triggered = true;
        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if (collidedDraggable != null)
        {
            _attach(_dragController.LastDragged.gameObject);
            _dragController.LastDragged.gameObject.transform.position = gameObject.transform.position;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Triggered = false;
    }

    private void _attach(GameObject g)
    {
        AtachedItems.Add(g);
    }
}
