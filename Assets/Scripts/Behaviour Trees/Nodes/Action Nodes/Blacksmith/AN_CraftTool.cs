using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_CraftTool : AN_Base
{
    AI_Blacksmith blacksmith;
    Storage storage;

    protected override void OnStart()
    {
        blacksmith = agent.blacksmith;
        storage = blacksmith.storage;

        CraftTool();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void CraftTool()
    {
        if(blacksmith.IronCollected > 0 && blacksmith.WoodCollected > 0 && blacksmith.atAnvil)
        {
            if(blacksmith.hasPickaxe == false && storage.PickaxeStation.HasTool == false)
            {
                blacksmith.IronCollected--;
                blacksmith.WoodCollected--;

                blacksmith.hasPickaxe = true;
            }
            else if(blacksmith.hasAxe == false && storage.AxeStation.HasTool == false)
            {
                blacksmith.IronCollected--;
                blacksmith.WoodCollected--;

                blacksmith.hasAxe = true;
            }
        }
    }
}
