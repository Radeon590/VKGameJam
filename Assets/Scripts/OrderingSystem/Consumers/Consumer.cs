using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumer", menuName = "ScriptableObjects/Consumer")]
public class Consumer : ScriptableObject
{
    public Sprite Sprite;
    public int Appetite = 1;
    public List<Meal> Wishes;
}
