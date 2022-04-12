using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_CraftTool : Goal_Base
{
    [SerializeField] int Priority = 90;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        if (Agent.blacksmith.hasAxe == false && Agent.blacksmith.hasPickaxe == false && 
            (Agent.blacksmith.storage.PickaxeStation.HasTool == false || Agent.blacksmith.storage.AxeStation.HasTool == false)
            && Agent.blacksmith.IronCollected > 0 && Agent.blacksmith.WoodCollected > 0)
            return true;

        return false;
    }
}
