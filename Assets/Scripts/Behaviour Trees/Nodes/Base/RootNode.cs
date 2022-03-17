using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : Node_Base
{
    [HideInInspector] public Node_Base child;

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        return child.Update();
    }

    public override Node_Base Clone()
    {
        RootNode node = Instantiate(this);
        node.child = child.Clone();
        return node;
    }
}
