using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Controller
{
    private void Update()
    {
        
    }

    public override void Activate()
    {
        enabled = true;
        base.Activate();
    }

    public override void Deactivate() 
    { 
        enabled = false;
        base.Deactivate();
    }
}
