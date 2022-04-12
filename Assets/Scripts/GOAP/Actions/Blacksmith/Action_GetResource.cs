using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_GetResource : Action_Base
{
    //list of the goals this action can help complete
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_GetResource) });

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
            GetResource();
        }
    }

    void AssignPosition()
    {
        if (Agent.blacksmith.IronCollected <= 0)
            moveToPosition = Agent.blacksmith.storage.IronStoragePosition.transform.position;
        else if(Agent.blacksmith.WoodCollected <= 0)
            moveToPosition = Agent.blacksmith.storage.WoodStoragePosition.transform.position;
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

    void GetResource()
    {
        if(Agent.blacksmith.IronCollected <= 0)
        {
            Agent.blacksmith.IronCollected++;
            Agent.blacksmith.storage.TakeIron(1);

            AssignPosition();
            Agent.navMeshAgent.SetDestination(moveToPosition);
        }
        else if (Agent.blacksmith.WoodCollected <= 0)
        {
            Agent.blacksmith.WoodCollected++;
            Agent.blacksmith.storage.TakeWood(1);
        }
    }
}
