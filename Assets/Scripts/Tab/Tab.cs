using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public virtual void OpenTab()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseTab()
    {
        gameObject.SetActive(false);
    }
}
