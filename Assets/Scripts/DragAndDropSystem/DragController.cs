using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;
    private DropValidItem[] _dvitems;
    private bool _dropped = false;
    
    private void Start()
    {
        _dvitems = FindObjectsByType<DropValidItem>(FindObjectsSortMode.None);
    }

    void Update()
    {
        if (_dropped)
        {
            _dropped = false;
            ManualTeleport();
        }
        if (_isDragActive && (Input.GetMouseButtonUp(0) ||
                              (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }

        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    private void Drop()
    {
        UpdateDragStatus(false);
        _dropped = true;
    }

    private void ManualTeleport()
    {
        bool triggered = false;
        foreach (var i in _dvitems)
        {
            if (i.Triggered)
            {
                triggered = true;
                break;
            }
        }
        var meal = _lastDragged.gameObject.GetComponent<DragableMealComponent>();

        if (triggered == false)
        {
            if (meal != null) meal.NullSprite();
            _lastDragged.gameObject.transform.position = _lastDragged._spawnpos;
        }
        else
        {
            if (meal != null) meal.BoardSprite();
        }
    }
    
    private void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    private void InitDrag()
    {
        UpdateDragStatus(true);
        var meal = _lastDragged.gameObject.GetComponent<DragableMealComponent>();
        if (meal != null)
        {
            meal.DragSprite();
        }
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragActive = _lastDragged.IsDragging = isDragging;
        _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
        
    }
}
