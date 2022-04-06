using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_PerformStorageAction : AN_Base
{
    AI_Worker worker;

    protected override void OnStart()
    {
        worker = agent.worker;

        PerformAction();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void PerformAction()
    {
        worker.storage.StoreIron(worker.IronCollected);
        worker.storage.StoreWood(worker.WoodCollected);

        worker.IronCollected = 0;
        worker.WoodCollected = 0;
    }
}
