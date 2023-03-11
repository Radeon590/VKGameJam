using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RatingInfo : IinfoContainer
{
    public float ConsumersRating;

    public void LoadInfo()
    {
        ConsumersRating = 0.5f;
    }
}
