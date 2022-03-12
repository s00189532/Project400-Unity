using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Idle : Goal_Base
{
    [SerializeField] int Priority = 10;

    public override int CalculatePriority()
    {
        return Priority;
    }

    //Goal_Idle can always run and used as fallback Goal
    public override bool CanRun()
    {
        return true;
    }
}
