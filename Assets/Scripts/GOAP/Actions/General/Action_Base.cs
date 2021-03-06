using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Base : MonoBehaviour
{
    protected AI_Agent Agent;
    protected Goal_Base LinkedGoal;

    private void Awake()
    {
        Agent = GetComponent<AI_Agent>();
    }

    //gets the goals that an action can accomplish
    public virtual List<System.Type> GetSupportedGoals()
    {
        return null;
    }

    public virtual float GetCost()
    {
        return 0f;
    }

    public virtual void OnActivated(Goal_Base _linkedGoal)
    {
        LinkedGoal = _linkedGoal;
    }

    public virtual void OnDeactivated()
    {
        LinkedGoal = null;
    }

    public virtual void OnTick()
    {

    }
}
