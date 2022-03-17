using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CN_Base : Node_Base
{
    [HideInInspector] public List<Node_Base> children = new List<Node_Base>();

    public override Node_Base Clone()
    {
        CN_Base node = Instantiate(this);
        node.children = children.ConvertAll(c => c.Clone());
        return node;
    }
}
