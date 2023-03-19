using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    public UnityEvent OnActivate;

    public virtual void Activate()
    {
        ControlsManager.ActiveControllers.Add(this);
        gameObject.SetActive(true);
    }

    public UnityEvent OnDeactivate;

    public virtual void Deactivate() 
    {
        ControlsManager.ActiveControllers.Remove(this);
        gameObject.SetActive(false);
    }
}
