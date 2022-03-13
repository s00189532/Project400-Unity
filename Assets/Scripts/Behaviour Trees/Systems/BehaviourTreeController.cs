using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeController : MonoBehaviour
{
    BehaviourTree tree;

    private void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviourTree>();

        var log1 = ScriptableObject.CreateInstance<AN_DebugLog>();
        log1.message = "Hello World 1!";

        var pause1 = ScriptableObject.CreateInstance<AN_Wait>();
        
        var log2 = ScriptableObject.CreateInstance<AN_DebugLog>();
        log2.message = "Hello World 2!";

        var pause2 = ScriptableObject.CreateInstance<AN_Wait>();

        var log3 = ScriptableObject.CreateInstance<AN_DebugLog>();
        log3.message = "Hello World 3!";

        var pause3 = ScriptableObject.CreateInstance<AN_Wait>();

        var sequence = ScriptableObject.CreateInstance<CN_Sequence>();
        sequence.children.Add(log1);
        sequence.children.Add(pause1);

        sequence.children.Add(log2);
        sequence.children.Add(pause2);

        sequence.children.Add(log3);
        sequence.children.Add(pause3);

        var loop = ScriptableObject.CreateInstance<DN_Repeat>();
        loop.child = sequence;

        tree.rootNode = loop;
    }

    private void Update()
    {
        tree.Update();
    }
}
