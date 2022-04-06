using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_GetTool : AN_Base
{
    AI_Worker worker;
    ToolStation station;

    protected override void OnStart()
    {
        worker = agent.worker;

        GetStation();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if(CheckStation())
        {
            return State.Success;
        }
        else
        {
            return State.Running;
        }
    }

    void GetStation()
    {
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                station = worker.storage.PickaxeStation;
                break;
            case AI_Worker.AIRole.Lumberjack:
                station = worker.storage.AxeStation;
                break;
            default:
                break;
        }
    }

    bool CheckStation()
    {
        if(station.HasTool)
        {
            worker.ShowTool();
            station.DestroyTool();
            return true;
        }
        else
        {
            return false;
        }
    }
}
