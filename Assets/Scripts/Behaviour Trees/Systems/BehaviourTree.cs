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

    public BlackBoard blackboard = new BlackBoard();

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

        Undo.RecordObject(this, "Behaviour Tree (CreateNode)");

        nodes.Add(node);

        if (!Application.isPlaying)
        {
            AssetDatabase.AddObjectToAsset(node, this);
        }

        Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree (CreateNode)");
        AssetDatabase.SaveAssets();

        return node;
    }

    public void DeleteNode(Node_Base node)
    {
        Undo.RecordObject(this, "Behaviour Tree (DeleteNode)");
        nodes.Remove(node);

        //AssetDatabase.RemoveObjectFromAsset(node);
        Undo.DestroyObjectImmediate(node);
        AssetDatabase.SaveAssets();
    }

    public void AddChild(Node_Base parent, Node_Base child)
    {
        DN_Base decorator = parent as DN_Base;
        if (decorator)
        {
            Undo.RecordObject(decorator, "Behaviour Tree (AddChild)");
            decorator.child = child;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behaviour Tree (AddChild)");
            rootNode.child = child;
            EditorUtility.SetDirty(rootNode);
        }

        CN_Base composite = parent as CN_Base;
        if (composite)
        {
            Undo.RecordObject(composite, "Behaviour Tree (AddChild)");
            composite.children.Add(child);
            EditorUtility.SetDirty(composite);
        }
    }

    public void RemoveChild(Node_Base parent, Node_Base child)
    {
        DN_Base decorator = parent as DN_Base;
        if (decorator)
        {
            Undo.RecordObject(decorator, "Behaviour Tree (RemoveChild)");
            decorator.child = null;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behaviour Tree (RemoveChild)");
            rootNode.child = null;
            EditorUtility.SetDirty(rootNode);
        }

        CN_Base composite = parent as CN_Base;
        if (composite)
        {
            Undo.RecordObject(composite, "Behaviour Tree (RemoveChild)");
            composite.children.Remove(child);
            EditorUtility.SetDirty(composite);
        }
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

    public void Traverse(Node_Base node, System.Action<Node_Base> visiter)
    {
        if (node)
        {
            visiter.Invoke(node);
            var children = GetChildren(node);

            //Depth first traverse through children nodes
            children.ForEach((n) => Traverse(n, visiter));
        }
    }

    //Creates clones of a behaviour tree so gameobjects using the tree don't use the same tree but use clones of it instead
    public BehaviourTree Clone()
    {
        BehaviourTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        tree.nodes = new List<Node_Base>();

        //Traverses through nodes of the tree starting at the root node and adds them to the trees list of nodes
        Traverse(tree.rootNode, (n) =>
        {
            tree.nodes.Add(n);
        });

        return tree;
    }

    public void Bind()
    {
        Traverse(rootNode, node =>
        {
            node.blackboard = blackboard;
        });
    }
}
