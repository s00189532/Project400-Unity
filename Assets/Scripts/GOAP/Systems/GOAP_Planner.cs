using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAP_Planner : MonoBehaviour
{
    Goal_Base[] Goals;
    Action_Base[] Actions;

    Goal_Base ActiveGoal;
    Action_Base ActiveAction;

    void Awake()
    {
        Goals = GetComponents<Goal_Base>();
        Actions = GetComponents<Action_Base>();
    }

    void Update()
    {
        Goal_Base bestGoal = null;
        Action_Base bestAction = null;

        // find the highest priority goal that can be activated
        foreach (var goal in Goals)
        {
            // tick goal
            goal.OnTickGoal();

            // if goal can not be run then skip it
            if (!goal.CanRun())
                continue;

            // if goal priority is worse than the current bestGoal then skip it
            if (!(bestGoal == null || goal.CalculatePriority() > bestGoal.CalculatePriority()))
                continue;

            // find the best cost action
            Action_Base candidateAction = null;
            foreach (var action in Actions)
            {
                //if action does not support this goal then skip it
                if (!action.GetSupportedGoals().Contains(goal.GetType()))
                    continue;

                // if candidate action is empty assign action to it
                // if candidate action is not empty and the cost of action is lower then it reassign it with action
                // otherwise skip it
                if (candidateAction == null || action.GetCost() < candidateAction.GetCost())
                    candidateAction = action;
            }

            // if by the end the candidate action is not null reassign bestGoal with goal and candidateAction with action
            if (candidateAction != null)
            {
                bestGoal = goal;
                bestAction = candidateAction;
            }
        }

        //Once bestAction and bestGoal are found
        // if there is no currentGoal
        if (ActiveGoal == null)
        {
            //assign bestGoal and bestAction to ActiveGoal and ActiveAction
            ActiveGoal = bestGoal;
            ActiveAction = bestAction;

            Debug.Log(ActiveGoal + " - " + ActiveAction);

            //if assigned they are not null (bestAction and bestGoal are not null when assigned to them are not null) activate them
            if (ActiveGoal != null)
                ActiveGoal.OnGoalActivated(ActiveAction);
            if (ActiveAction != null)
                ActiveAction.OnActivated(ActiveGoal);
        } 
        // if current goal is already bestGoal and nothing has changed
        else if (ActiveGoal == bestGoal)
        {
            // if action has changed
            if (ActiveAction != bestAction)
            {
                // deactivate old action
                ActiveAction.OnDeactivated();

                // reassign current action to new bestAction
                ActiveAction = bestAction;

                Debug.Log(ActiveGoal + " - " + ActiveAction);

                // activate new action
                ActiveAction.OnActivated(ActiveGoal);
            }
        }
        // if current goal is not the same as new goal or new goal is not assigned a valid goal
        else if (ActiveGoal != bestGoal)
        {
            // deactive current goal and action
            ActiveGoal.OnGoalDeactivated();
            ActiveAction.OnDeactivated();

            // reassign the current goal and action to new bestGoal and bestAction
            ActiveGoal = bestGoal;
            ActiveAction = bestAction;

            Debug.Log(ActiveGoal + " - " + ActiveAction);

            //if the assignments are not null activate them
            if (ActiveGoal != null)
                ActiveGoal.OnGoalActivated(ActiveAction);
            if (ActiveAction != null)
                ActiveAction.OnActivated(ActiveGoal);
        }

        // tick the action
        if (ActiveAction != null)
            ActiveAction.OnTick();
    }
}
