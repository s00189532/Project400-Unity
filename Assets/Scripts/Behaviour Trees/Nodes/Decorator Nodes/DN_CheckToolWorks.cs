using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DN_CheckToolWorks : DN_Base
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (agent.worker.HasTool)
        {
            child.Update();
            return State.Running;
        }
        else
            return State.Failure;
    }
}
