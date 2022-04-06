using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_AssignMaterialPosition : AN_Base
{
    AI_Blacksmith blacksmith;
    Storage storage;

    protected override void OnStart()
    {
        blacksmith = agent.blacksmith;
        storage = agent.blacksmith.storage;

        AssignPosition();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void AssignPosition()
    {
        if (blacksmith.IronCollected <= 0 && storage.GetIron() > 0)
        {
            blackboard.moveToPosition = blacksmith.storage.IronStoragePosition.transform.position;
        }
        else if (blacksmith.WoodCollected <= 0 && storage.GetWood() > 0)
        {
            blackboard.moveToPosition = blacksmith.storage.WoodStoragePosition.transform.position;
        }
        else
        {
            blackboard.moveToPosition = agent.blacksmith.anvil.BlacksmithPosition.transform.position;
        }
    }
}
