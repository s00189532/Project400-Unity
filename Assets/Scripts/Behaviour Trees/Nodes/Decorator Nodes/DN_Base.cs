using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DN_Base : Node_Base
{
    [HideInInspector] public Node_Base child;

    public override Node_Base Clone()
    {
        DN_Base node = Instantiate(this);
        node.child = child.Clone();
        return node;
    }
}
