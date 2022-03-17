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

    public void AddChild(Node_Base parent, Node_Base child)
    {
        DN_Base decorator = parent as DN_Base;
        if (decorator)
            decorator.child = child;

        RootNode rootNode = parent as RootNode;
        if(rootNode)
        {
            rootNode.child = child;
        }

        CN_Base composite = parent as CN_Base;
        if (composite)
            composite.children.Add(child);
    }

    public void RemoveChild(Node_Base parent, Node_Base child)
    {
        DN_Base decorator = parent as DN_Base;
        if (decorator)
            decorator.child = null;

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            rootNode.child = null;
        }

        CN_Base composite = parent as CN_Base;
        if (composite)
            composite.children.Remove(child);
    }

    public List<Node_Base> GetChildren(Node_Base parent)
    {
        List<Node_Base> children = new List<Node_Base>();

        DN_Base decorator = parent as DN_Base;
        if (decorator && decorator.child != null)
            children.Add(decorator.child);

        RootNode rootNode = parent as RootNode;
        if (rootNode && rootNode.child != null)
        {
            children.Add(rootNode.child);
        }

        CN_Base composite = parent as CN_Base;
        if (composite && composite.children != null)
            children = composite.children;

        return children;
    }

    public BehaviourTree Clone()
    {
        BehaviourTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        return tree;
    }
}
