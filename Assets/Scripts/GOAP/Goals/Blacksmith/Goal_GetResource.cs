using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_GetResource : Goal_Base
{
    [SerializeField] int Priority = 80;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        if ((Agent.blacksmith.IronCollected <= 0 && Agent.blacksmith.storage.GetIron() > 0) || (Agent.blacksmith.WoodCollected <= 0 && Agent.blacksmith.storage.GetWood() > 0))
            return true;

        return false;
    }
}
