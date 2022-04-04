using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wait for a defined duration
public class AN_Test : AN_Base
{
    public bool testBool = false;

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (testBool)
            return State.Success;
        else
            return State.Failure; 
    }
}
