using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_HarvestResource : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_HarvestResource) });

    Goal_HarvestResource GHR;

    Vector3 moveToPosition;

    float startTime;
    bool timerRunning = false;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        base.OnActivated(_linkedGoal);
        GHR = (Goal_HarvestResource)LinkedGoal;

        AssignPosition();
        Agent.navMeshAgent.SetDestination(moveToPosition);
    }

    public override void OnTick()
    {
        base.OnTick();

        if (AtTargetPosition())
        {
            if (Wait())
            {
                timerRunning = false;
                GatherResource();

                Agent.worker.ToolDurability -= 10;

                if (Agent.worker.ToolDurability <= 0)
                    Agent.worker.HideTool();
            }
        }
    }

    void AssignPosition()
    {
        switch (Agent.worker.role)
        {
            case AI_Worker.AIRole.Miner:
                moveToPosition = Agent.worker.ironPos;
                break;
            case AI_Worker.AIRole.Lumberjack:
                moveToPosition = Agent.worker.woodPos;
                break;
            default:
                break;
        }
    }

    bool AtTargetPosition()
    {
        Vector3 distanceToTarget = Agent.transform.position - moveToPosition;
        distanceToTarget.y = 0;

        if (distanceToTarget.magnitude <= 0.1f)
            return true;
        else
            return false;
    }

    bool Wait()
    {
        if (!timerRunning)
        {
            startTime = Time.time;
            timerRunning = true;
        }

        if (Time.time - startTime > GHR.TimeToWait && timerRunning)
        {
            return true;
        }


        return false;
    }

    void GatherResource()
    {
        switch (Agent.worker.role)
        {
            case AI_Worker.AIRole.Miner:
                Agent.worker.IronCollected++;
                break;
            case AI_Worker.AIRole.Lumberjack:
                Agent.worker.WoodCollected++;
                break;
            default:
                break;
        }
    }
}
