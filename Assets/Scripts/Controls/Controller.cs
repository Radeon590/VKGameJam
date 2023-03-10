using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public virtual void Activate()
    {
        ControlsManager.ActiveControllers.Add(this);
    }

    public virtual void Deactivate() 
    {
        ControlsManager.ActiveControllers.Remove(this);
    }
}
