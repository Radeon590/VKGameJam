using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Controller
{
    private TaskPoint _taskPoint;
    private float _speed = 1;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_taskPoint != null)
            {
                _taskPoint.OrderAction();
            }
        }
    }

    public override void Activate()
    {
        enabled = true;
        base.Activate();
    }

    public override void Deactivate() 
    { 
        enabled = false;
        base.Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out _taskPoint))
        {
            GetComponent<EmotionalPerson>().ShowEmoje(EmojiTypes.Glad);
            _taskPoint.EnterPointAction();
        }
        else
        {
            CookingPoint cookingPoint;
            if(collision.gameObject.TryGetComponent(out cookingPoint))
            {
                cookingPoint.StartCooking();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out _taskPoint))
        {
            _taskPoint.ExitPointAction();
            _taskPoint = null;
        }
    }
}
