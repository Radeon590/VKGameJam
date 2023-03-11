using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaschine : MonoBehaviour
{
    [SerializeField] private GameObject CloseTabButton;
    [SerializeField] private MainTab mainTab;

    private void Start()
    {
        InitializaeGame();
    }

    public void InitializaeGame()
    {
        GetComponent<SingletoneInfoContainer>().LoadInfo();
    }

    public void StartPreparing()
    {
        mainTab.OpenTab();
        CloseTabButton.SetActive(true);
    }

    public void StartShift()
    {
        mainTab.CloseTab();
        CloseTabButton.SetActive(false);
    }
}
