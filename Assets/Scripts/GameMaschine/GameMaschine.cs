using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMaschine : MonoBehaviour
{
    [SerializeField] private CarsSpawner carsSpawner;
    [SerializeField] private GameObject closeTabButton;
    [SerializeField] private MainTab mainTab;

    public UnityEvent OnShiftStarted = new UnityEvent();
    public UnityEvent OnShiftEnded = new UnityEvent();

    private bool _isShiftInProgress = false;
    private static float s_shiftTimer = -100;
    public static float ShiftTimer
    {
        get { return s_shiftTimer; }
    }

    private void Start()
    {
        InitializaeGame();
        StartPreparing();
        //StartShift();
    }

    private void Update()
    {
        if(_isShiftInProgress)
        {
            s_shiftTimer -= Time.deltaTime;
            if(s_shiftTimer < 0)
            {
                EndShift();
            }
        }
    }

    public void InitializaeGame()
    {
        GetComponent<SingletoneInfoContainer>().LoadInfo();
        carsSpawner.StartSpawning();
    }

    public void StartPreparing()
    {
        mainTab.OpenTab();
        closeTabButton.SetActive(true);
    }

    public void StartShift()
    {
        s_shiftTimer = 300;
        _isShiftInProgress = true;
        closeTabButton.SetActive(false);
        OnShiftStarted.Invoke();
    }

    public void EndShift()
    {
        _isShiftInProgress = false;
        closeTabButton.SetActive(true);
        OnShiftEnded.Invoke();
    }
}
