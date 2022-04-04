using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_ToolCheck : AN_Base
{
    AI_Worker worker;

    Vector3 wood;
    Vector3 iron;

    protected override void OnStart()
    {
        Debug.Log("Tool Check");

        worker = agent.worker;
        wood = worker.woodPos;
        iron = worker.ironPos;

        if (worker.HasTool)
            AssignWorkPosition();
        else
            AssignStoragePosition();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void AssignWorkPosition()
    {
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                blackboard.moveToPosition = iron;
                break;
            case AI_Worker.AIRole.Lumberjack:
                blackboard.moveToPosition = wood;
                break;
            case AI_Worker.AIRole.BlackSmith:
                break;
            default:
                break;
        }
    }

    void AssignStoragePosition()
    {
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                blackboard.moveToPosition = worker.storage.IronStoragePosition.transform.position;
                break;
            case AI_Worker.AIRole.Lumberjack:
                blackboard.moveToPosition = worker.storage.WoodStoragePosition.transform.position;
                break;
            case AI_Worker.AIRole.BlackSmith:
                break;
            default:
                break;
        }
    }

}
