using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_DepositReource : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_DepositResource) });

    Goal_DepositResource GDR;

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
        GDR = (Goal_DepositResource)LinkedGoal;

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
                DepositResource();
            }
        }
    }

    void AssignPosition()
    {
        switch (Agent.worker.role)
        {
            case AI_Worker.AIRole.Miner:
                moveToPosition = Agent.worker.storage.IronStoragePosition.transform.position;
                break;
            case AI_Worker.AIRole.Lumberjack:
                moveToPosition = Agent.worker.storage.WoodStoragePosition.transform.position;
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

        if (Time.time - startTime > GDR.TimeToWait)
        {
            return true;
        }

        return false;
    }

    void DepositResource()
    {
        Agent.worker.storage.StoreIron(Agent.worker.IronCollected);
        Agent.worker.storage.StoreWood(Agent.worker.WoodCollected);

        Agent.worker.IronCollected = 0;
        Agent.worker.WoodCollected = 0;
    }
}
