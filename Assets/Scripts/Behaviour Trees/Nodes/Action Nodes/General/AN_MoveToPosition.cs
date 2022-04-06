using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_MoveToPosition : AN_Base
{
    protected override void OnStart()
    {
        agent.navMeshAgent.SetDestination(blackboard.moveToPosition);
        Debug.Log(blackboard.moveToPosition);
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        Vector3 distanceToTarget = agent.transform.position - blackboard.moveToPosition;
        distanceToTarget.y = 0;

        if (distanceToTarget.magnitude <= 0.1f)
            return State.Success;
        else
            return State.Running;
    }
}
