using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CafeInfo : IinfoContainer
{
    public float ConsumersRating;
    public int Capacity;

    public void LoadInfo()
    {
        ConsumersRating = 0.5f;
        Capacity = 3;
    }
}
