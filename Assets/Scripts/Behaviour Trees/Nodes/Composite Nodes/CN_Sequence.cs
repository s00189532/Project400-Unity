using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Executes all child nodes in order until all nodes return success or one returns failure
public class CN_Sequence : CN_Base
{
    int current;

    protected override void OnStart()
    {
        current = 0;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        //switch on child nodes checking what state they are in
        var child = children[current];
        switch (child.Update())
        {
            case State.Running:
                return State.Running;
            case State.Failure:
                return State.Failure;
            case State.Success:
                current++;
                break;
        }

        // if all child nodes have successfully executed return success otherwise return running
        return current == children.Count ? State.Success : State.Running;
    }
}
