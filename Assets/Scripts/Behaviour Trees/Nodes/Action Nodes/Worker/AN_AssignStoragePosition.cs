using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_AssignStoragePosition : AN_Base
{
    AI_Worker worker;

    protected override void OnStart()
    {
        worker = agent.worker;
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
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                blackboard.moveToPosition = worker.storage.IronStoragePosition.transform.position;
                break;
            case AI_Worker.AIRole.Lumberjack:
                blackboard.moveToPosition = worker.storage.WoodStoragePosition.transform.position;
                break;
            default:
                break;
        }
    }
}
