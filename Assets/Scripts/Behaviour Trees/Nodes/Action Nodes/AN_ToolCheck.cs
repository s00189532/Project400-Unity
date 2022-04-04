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
        worker = agent.worker;
        wood = worker.woodPos;
        iron = worker.ironPos;

        if (worker.HasTool)
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
}
