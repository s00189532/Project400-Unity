using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_DepositResource : Goal_Base
{
    [SerializeField] int Priority = 90;

    public float TimeToWait = 3f;
    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        if(Agent.worker.IronCollected > 0 || Agent.worker.WoodCollected > 0)
            return true;

        return false;
    }
}
