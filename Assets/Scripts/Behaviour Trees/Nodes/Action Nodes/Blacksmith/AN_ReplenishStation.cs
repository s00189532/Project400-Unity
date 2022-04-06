using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_ReplenishStation : AN_Base
{
    AI_Blacksmith blacksmith;
    Storage storage;

    protected override void OnStart()
    {
        blacksmith = agent.blacksmith;
        storage = blacksmith.storage;

        ReplenishStation();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void ReplenishStation()
    {
        if(storage.PickaxeStation.HasTool == false && blacksmith.hasPickaxe)
        {
            storage.PickaxeStation.SpawnTool();
            blacksmith.hasPickaxe = false;
        }
        else if(storage.AxeStation.HasTool == false && blacksmith.hasAxe)
        {
            storage.AxeStation.SpawnTool();
            blacksmith.hasAxe = false;
        }
    }
}
