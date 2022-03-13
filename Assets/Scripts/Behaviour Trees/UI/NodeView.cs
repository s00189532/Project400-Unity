using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public Node_Base node;

    public NodeView(Node_Base node)
    {
        this.node = node;
        this.title = node.name;
    }
}
