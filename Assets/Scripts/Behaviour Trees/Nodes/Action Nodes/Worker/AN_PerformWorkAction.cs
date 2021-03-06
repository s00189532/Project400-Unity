using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_PerformWorkAction : AN_Base
{
    AI_Worker worker;

    protected override void OnStart()
    {
        worker = agent.worker;

        RoleCheck();
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return State.Success;
    }

    void RoleCheck()
    {
        switch (worker.role)
        {
            case AI_Worker.AIRole.Miner:
                HarvestResource(true);
                break;
            case AI_Worker.AIRole.Lumberjack:
                HarvestResource(false);
                break;
            default:
                break;
        }
    }

    void HarvestResource(bool iron)
    {
        worker.ToolDurability -= 10;

        if (iron)
            worker.IronCollected++;
        else
            worker.WoodCollected++;

        if (worker.ToolDurability <= 0)
        {
            worker.HideTool();
        }
    }
}
