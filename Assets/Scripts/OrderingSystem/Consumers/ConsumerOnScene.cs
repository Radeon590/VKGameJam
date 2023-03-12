using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumerOnScene : MonoBehaviour
{
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

    public Vector2 DestinationPoint
    {
        set
        {

        }
    }

    public UnityEvent OnConsumerInDestinationPoint;
    public UnityEvent OnConsumerGaneOrder;

    void Update()
    {
        
    }
}
