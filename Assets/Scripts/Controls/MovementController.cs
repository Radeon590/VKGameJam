using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Controller
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
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
