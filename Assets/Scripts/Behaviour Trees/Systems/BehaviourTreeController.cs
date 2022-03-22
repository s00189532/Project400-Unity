using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeController : MonoBehaviour
{
    public BehaviourTree tree;

    private void Start()
    {
        tree = tree.Clone();
        tree.Bind();
    }

    private void Update()
    {
        tree.Update();
    }
}
