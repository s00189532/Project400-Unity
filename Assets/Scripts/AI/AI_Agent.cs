using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Agent : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public AI_Worker worker;
    [HideInInspector] public AI_Blacksmith blacksmith;

    void Start()
    {
        TryGetComponent(out navMeshAgent);
        TryGetComponent(out worker);
        TryGetComponent(out blacksmith);
    }

}
