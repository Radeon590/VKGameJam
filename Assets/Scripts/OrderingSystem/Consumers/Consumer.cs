using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumer", menuName = "ScriptableObjects/Consumer")]
public class Consumer : ScriptableObject
{
    public Sprite Sprite;
    public (int, int) AppetiteRange = (1, 2);
    public List<Meal> Wishes;

    public Consumer()
    {

    }

    public Consumer(List<Meal> Wishes)
    {
        this.Wishes = Wishes;
    }
}
