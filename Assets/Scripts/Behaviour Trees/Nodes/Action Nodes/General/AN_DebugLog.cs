using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Writes debug message to console on start, update and stop
public class AN_DebugLog : AN_Base
{
    public string message;

    protected override void OnStart()
    {
        Debug.Log("OnStart : " + message);
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
