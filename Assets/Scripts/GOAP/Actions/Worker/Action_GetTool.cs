using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_GetTool : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_GetTool) });

    Vector3 moveToPosition;

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

        AssignPosition();
        Agent.navMeshAgent.SetDestination(moveToPosition);
    }

    public override void OnTick()
    {
        base.OnTick();

        if (AtTargetPosition())
        {
            GetTool();
        }
    }

    void AssignPosition()
    {
        switch (Agent.worker.role)
        {
            case AI_Worker.AIRole.Miner:
                moveToPosition = Agent.worker.storage.PickaxeStation.ToolUserPos.transform.position;
                break;
            case AI_Worker.AIRole.Lumberjack:
                moveToPosition = Agent.worker.storage.AxeStation.ToolUserPos.transform.position;
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

    void GetTool()
    {
        switch (Agent.worker.role)
        {
            case AI_Worker.AIRole.Miner:
                GetPickaxe();
                break;
            case AI_Worker.AIRole.Lumberjack:
                GetAxe();
                break;
            default:
                break;
        }

    }

    void GetPickaxe()
    {
        if (Agent.worker.storage.PickaxeStation.HasTool)
        {
            Agent.worker.ShowTool();
            Agent.worker.storage.PickaxeStation.DestroyTool();
        }
    }

    void GetAxe()
    {
        if (Agent.worker.storage.AxeStation.HasTool)
        {
            Agent.worker.ShowTool();
            Agent.worker.storage.AxeStation.DestroyTool();
        }
    }
}
