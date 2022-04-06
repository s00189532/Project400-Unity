using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_CollectMaterial : AN_Base
{
    AI_Blacksmith blacksmith;
    Storage storage;

    protected override void OnStart()
    {
        blacksmith = agent.blacksmith;
        storage = agent.blacksmith.storage;

        CollectMaterial();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void CollectMaterial()
    {
        if (blacksmith.IronCollected <= 0 && storage.GetIron() > 0)
        {
            blacksmith.IronCollected++;
            storage.TakeIron(1);
        }
        else if (blacksmith.WoodCollected <= 0 && storage.GetWood() > 0)
        {
            blacksmith.WoodCollected++;
            storage.TakeWood(1);
        }
    }
}
