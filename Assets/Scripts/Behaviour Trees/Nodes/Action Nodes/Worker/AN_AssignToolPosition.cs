using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_AssignToolPosition : AN_Base
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
        Debug.Log(blackboard.moveToPosition);
        return State.Success;
    }

    void AssignPosition()
    {
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                blackboard.moveToPosition = worker.storage.PickaxeStation.ToolUserPos.transform.position;
                break;
            case AI_Worker.AIRole.Lumberjack:
                blackboard.moveToPosition = worker.storage.AxeStation.ToolUserPos.transform.position;
                break;
            default:
                break;
        }
    }
}
