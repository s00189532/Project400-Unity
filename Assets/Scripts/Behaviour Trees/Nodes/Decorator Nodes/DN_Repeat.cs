using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Repeats the update of it's child node
public class DN_Repeat : DN_Base
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        child.Update();
        return State.Running;
    }
}
