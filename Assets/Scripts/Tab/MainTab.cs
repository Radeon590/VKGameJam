using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTab : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject marketScreen;
    [SerializeField] private GameObject bankScreen;

    public void OpenTab()
    {
        gameObject.SetActive(true);
    }

    public void CloseTab()
    {
        gameObject.SetActive(false);
    }

    public void OpenMarket()
    {

    }
}
