using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wait for a defined duration
public class AN_Wait : AN_Base
{
    public float duration = 1;
    float startTime;

    protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if(Time.time - startTime > duration)
        {
            return State.Success;
        }

        return State.Running;
    }
}
