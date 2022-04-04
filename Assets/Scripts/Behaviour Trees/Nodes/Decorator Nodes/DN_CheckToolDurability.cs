using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DN_CheckToolDurability : DN_Base
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (agent.worker.ToolDurability <= 0)
            return State.Failure;
        else
        {
            child.Update();
            return State.Success;
        }
    }
}
