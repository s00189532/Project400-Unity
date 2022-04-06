using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_CheckStations : AN_Base
{
    AI_Blacksmith blacksmith;
    Storage storage;

    protected override void OnStart()
    {
        blacksmith = agent.blacksmith;
        storage = blacksmith.storage;

        CheckStations();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void CheckStations()
    {
        if (blacksmith.hasPickaxe && storage.PickaxeStation.HasTool == false)
        {
            blackboard.moveToPosition = storage.PickaxeStation.BlacksmithPos.transform.position;
        }
        else if (blacksmith.hasAxe && storage.AxeStation.HasTool == false)
        {
            blackboard.moveToPosition = storage.AxeStation.BlacksmithPos.transform.position;
        }
    }
}
