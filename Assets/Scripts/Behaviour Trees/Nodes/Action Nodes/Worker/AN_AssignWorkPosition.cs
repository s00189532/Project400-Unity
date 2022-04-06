using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_AssignWorkPosition : AN_Base
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
                blackboard.moveToPosition = worker.ironPos;
                break;
            case AI_Worker.AIRole.Lumberjack:
                blackboard.moveToPosition = worker.woodPos;
                break;
            default:
                break;
        }
    }

}
