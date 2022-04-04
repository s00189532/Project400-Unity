using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeController : MonoBehaviour
{
    public BehaviourTree tree;

    private void Start()
    {
        tree = tree.Clone();
        tree.Bind(this.gameObject.GetComponent<AI_Agent>());
    }

    private void Update()
    {
        tree.Update();
    }
}
