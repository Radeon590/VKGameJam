using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    private Collider2D _collider;
    private DragController _dragController;
    public Vector2 _spawnpos;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
        _spawnpos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(Time.time);
        DropValidItem collided = other.GetComponent<DropValidItem>();

        if (collided != null)
        {
            collided.Triggered = true;
            collided.Attach(_dragController.LastDragged.gameObject);
            _dragController.LastDragged.gameObject.transform.position = collided.gameObject.transform.position;
        }
    }
}
