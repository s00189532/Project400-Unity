using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_DepositTool : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_DepositTool) });

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
            DepositTool();
        }
    }

    void AssignPosition()
    {
        if (Agent.blacksmith.hasPickaxe)
            moveToPosition = Agent.blacksmith.storage.PickaxeStation.BlacksmithPos.transform.position;
        else if (Agent.blacksmith.hasAxe)
            moveToPosition = Agent.blacksmith.storage.AxeStation.BlacksmithPos.transform.position;
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

    void DepositTool()
    {
        if (Agent.blacksmith.hasPickaxe)
        {
            Agent.blacksmith.hasPickaxe = false;
            Agent.blacksmith.storage.PickaxeStation.SpawnTool();
        }
        else if (Agent.blacksmith.hasAxe)
        {
            Agent.blacksmith.hasAxe = false;
            Agent.blacksmith.storage.AxeStation.SpawnTool();
        }
    }
}
