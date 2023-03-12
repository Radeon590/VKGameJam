using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumerOnScene : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    public UnityEvent OnConsumerInDestinationPoint;
    public UnityEvent OnConsumerGaneOrder;

    private Consumer _consumer;

    public Consumer Consumer 
    { 
        get { return _consumer; }
        set
        {
            _consumer = value;
            GetComponent<SpriteRenderer>().sprite = value.Sprite;
        }
    }

    private Vector2 _destinationPoint;

    public Vector2 DestinationPoint
    {
        set
        {
            _destinationPoint = value;
            _move = true;
        }
    }

    private bool _move = false;

    void Update()
    {
        if (_move)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destinationPoint, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, _destinationPoint) < 0.5f)
            {
                OnConsumerInDestinationPoint.Invoke();
                _move = false;
                //
                OnConsumerGaneOrder.Invoke();
            }
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
