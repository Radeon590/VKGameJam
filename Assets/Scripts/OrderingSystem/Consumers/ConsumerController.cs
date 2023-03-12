using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ConsumerView))]
public class ConsumerController : MonoBehaviour
{
    [SerializeField] List<Consumer> consumers;

    private List<ConsumerOnScene> _consumersQueue = new List<ConsumerOnScene>();
    public List<ConsumerOnScene> ConsumersQueue 
    { 
        get { return _consumersQueue; }
        set
        {
            _consumersQueue = value;
        }
    }

    private List<MealComponent> _storageAfterConsuming;
    private List<int> _storageAfterConsumingNumbers;
    private float _nextConsumerTimer = 0;

    private void Update()
    {
        _nextConsumerTimer -= Time.deltaTime;
        if(_nextConsumerTimer < 0 && _consumersQueue.Count < SingletoneInfoContainer.CafeInfo.Capacity)
        {
            GenerateConsumer();
        }
    }

    public void StartConsuming()
    {
        RandomiseNextConsumerTime();
        _storageAfterConsuming = new List<MealComponent>(SingletoneInfoContainer.Storage.ComponentsInStorage);
        _storageAfterConsumingNumbers = new List<int>(SingletoneInfoContainer.Storage.ComponentsInStorageNumbers);
        enabled = true;
    }

    public void StopConsuming() 
    {
        _consumersQueue.Clear();
        _storageAfterConsuming = null;
        _storageAfterConsumingNumbers = null;
        enabled = false;
    }

    private void GenerateConsumer()
    {
        Consumer generatedConsumer = new Consumer(new List<Meal>());
        List<Consumer> consumersForCheck = new List<Consumer>(consumers);
        while (consumersForCheck.Count > 0)
        {
            generatedConsumer.Wishes.Clear();
            Consumer consumer = consumersForCheck[Random.Range(0, consumersForCheck.Count - 1)];
            List<Meal> mealsForCheck = new List<Meal>(consumer.Wishes);
            List<MealComponent> removedComponents = new List<MealComponent>();
            int appetite = Random.Range(0, consumer.AppetiteRange);
            bool isCanCook = false;
            while (appetite > 0)
            {
                var meal = mealsForCheck[Random.Range(0, mealsForCheck.Count - 1)];
                foreach (var component in meal.MealComponents)
                {
                    var listHelper = new ListsHelper<MealComponent>();
                    if (!(listHelper.ClearLists(_storageAfterConsuming, _storageAfterConsumingNumbers, component, 1)))
                    {
                        foreach(var removedComponent in removedComponents)
                        {
                            listHelper.AddToLists(_storageAfterConsuming, _storageAfterConsumingNumbers, removedComponent, 1);
                        }
                        mealsForCheck.Remove(meal);
                        isCanCook = true;
                        break;
                    }
                    removedComponents.Add(component);
                }
                if (isCanCook)
                {
                    generatedConsumer.Wishes.Add(meal);
                    appetite--;
                }
            }
            if(generatedConsumer.Wishes.Count > 0)
            {
                generatedConsumer.Sprite = consumer.Sprite;
                GetComponent<ConsumerView>().ShowConsumer(generatedConsumer);
                break;
            }
        }
        RandomiseNextConsumerTime();
    }

    private void RandomiseNextConsumerTime()
    {
        _nextConsumerTimer = Random.Range(1, 5 / SingletoneInfoContainer.CafeInfo.ConsumersRating);
    }
}
