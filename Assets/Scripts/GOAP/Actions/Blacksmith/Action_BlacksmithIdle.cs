using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_BlacksmithIdle : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_BlacksmithIdle) });

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

        moveToPosition = Agent.blacksmith.anvil.BlacksmithPosition.transform.position;
        Agent.navMeshAgent.SetDestination(moveToPosition);
    }
}
