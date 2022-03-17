using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class NodeView : Node
{
    public Action<NodeView> OnNodeSelected;

    public Node_Base node;

    public Port input;
    public Port output;

    public NodeView(Node_Base node)
    {
        this.node = node;
        this.title = node.name;
        this.viewDataKey = node.guid;

        style.left = node.position.x;
        style.top = node.position.y;

        CreateInputPorts();
        CreateOutputPorts();
    }

    private void CreateInputPorts()
    {
        if (node is AN_Base)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is CN_Base)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is DN_Base)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if(node is RootNode)
        {

        }

        if(input != null)
        {
            input.portName = "";
            inputContainer.Add(input);
        }
    }

    private void CreateOutputPorts()
    {
        if (node is AN_Base)
        {
        }
        else if (node is CN_Base)
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }
        else if (node is DN_Base)
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        } 
        else if (node is RootNode)
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        }

        if (output != null)
        {
            output.portName = "";
            outputContainer.Add(output);
        }
    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        node.position.x = newPos.xMin;
        node.position.y = newPos.yMin;
    }

    public override void OnSelected()
    {
        base.OnSelected();

        if(OnNodeSelected != null)
        {
            OnNodeSelected.Invoke(this);
        }
    }
}
