using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListsHelper<CleaningType>
{
    public bool ClearLists(List<CleaningType> list, List<int> listOfNumbers, CleaningType cleaningObject, int numberOfObjects)
    {
        if (list.Contains(cleaningObject))
        {
            int index = list.IndexOf(cleaningObject);
            if (listOfNumbers[index] > 1)
            {
                listOfNumbers[index] -= numberOfObjects;
            }
            else
            {
                list.RemoveAt(index);
                listOfNumbers.RemoveAt(index);
            }
            return true;
        }
        return false;
    }

    public void AddToLists(List<CleaningType> list, List<int> listOfNumbers, CleaningType addingObject, int numberOfObjects)
    {
        if (list.Contains(addingObject))
        {
            listOfNumbers[list.IndexOf(addingObject)] += numberOfObjects;
        }
        else
        {
            list.Add(addingObject);
            listOfNumbers.Add(numberOfObjects);
        }
    }
}
