using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerController : MonoBehaviour
{
    [SerializeField] List<Consumer> consumers;

    private List<Consumer> _consumersInStack;
    private float _nextConsumerTimer = 0;

    private void Update()
    {
        _nextConsumerTimer -= Time.deltaTime;
        if(_nextConsumerTimer < 0)
        {
            GenerateConsumer();
        }
    }

    public void StartConsuming()
    {
        RandomiseNextConsumerTime();
        enabled = true;
    }

    public void StopConsuming() 
    { 
        enabled = false;
    }

    private void GenerateConsumer()
    {

        RandomiseNextConsumerTime();
    }

    private void RandomiseNextConsumerTime()
    {
        _nextConsumerTimer = 10 / SingletoneInfoContainer.RatingInfo.ConsumersRating;
    }
}
