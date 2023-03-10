using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string Namespace;
    public Sprite Sprite;
    public Sprite Icon;
}
