using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_HarvestResource : Goal_Base
{
    [SerializeField] int Priority = 100;

    public float TimeToWait = 1f;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        return Agent.worker.HasTool;
    }
}
