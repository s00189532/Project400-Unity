using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_GetTool : Goal_Base
{
    [SerializeField] int Priority = 80;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        if (!Agent.worker.HasTool)
            return true;

        return false;
    }
}
