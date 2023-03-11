using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMaschine : MonoBehaviour
{
    [SerializeField] private GameObject closeTabButton;
    [SerializeField] private MainTab mainTab;
    [SerializeField] private ControlsManager controlsManager;
    [SerializeField] private MovementController movementController;

    public UnityEvent OnShiftStarted;
    public UnityEvent OnShiftEnded;

    private bool _isShiftInProgress = false;
    private static float s_shiftTimer = -100;
    public static float ShiftTimer
    {
        get { return s_shiftTimer; }
    }

    private void Start()
    {
        InitializaeGame();
        
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
        mainTab.CloseTab();
        closeTabButton.SetActive(false);
        movementController.Activate();
        OnShiftStarted?.Invoke();
    }

    public void EndShift()
    {
        _isShiftInProgress = false;
        OnShiftEnded?.Invoke();
    }
}
