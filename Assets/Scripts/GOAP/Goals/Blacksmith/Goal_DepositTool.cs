using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_DepositTool : Goal_Base
{
    [SerializeField] int Priority = 100;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        if (Agent.blacksmith.hasAxe || Agent.blacksmith.hasPickaxe)
            return true;

        return false;
    }
}
