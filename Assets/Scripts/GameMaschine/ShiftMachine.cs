using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftMachine : MonoBehaviour
{
    [SerializeField] private MainTab tab;

    public void StartPreparing()
    {
        tab.OpenTab();
    }

    public void StartShift()
    {
        tab.CloseTab();
    }
}
