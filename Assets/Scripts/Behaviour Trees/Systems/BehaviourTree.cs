using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
    public Node_Base rootNode;
    public Node_Base.State treeState = Node_Base.State.Running;

    public List<Node_Base> nodes = new List<Node_Base>();

    //when root node state is not running stop updating it
    public Node_Base.State Update()
    {
        if (rootNode.state == Node_Base.State.Running)
        {
            treeState = rootNode.Update();
        }

        return treeState;
    }

    public Node_Base CreateNode(System.Type type)
    {
        Node_Base node = ScriptableObject.CreateInstance(type) as Node_Base;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();

        nodes.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        AssetDatabase.SaveAssets();

        return node;
    }

    public void DeleteNode(Node_Base node)
    {
        nodes.Remove(node);

        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
    }
}
