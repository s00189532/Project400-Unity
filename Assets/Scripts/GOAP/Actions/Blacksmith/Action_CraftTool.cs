using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_CraftTool : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_CraftTool) });

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
            CraftTool();
        }
    }

    void AssignPosition()
    {
        moveToPosition = Agent.blacksmith.anvil.BlacksmithPosition.transform.position;
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

    void CraftTool()
    {
        Agent.blacksmith.IronCollected--;
        Agent.blacksmith.WoodCollected--;

        if(Agent.blacksmith.storage.PickaxeStation.HasTool == false)
        {
            Agent.blacksmith.hasPickaxe = true;
        }
        else if(Agent.blacksmith.storage.AxeStation.HasTool == false)
        {
            Agent.blacksmith.hasAxe = true;
        }
    }
}
