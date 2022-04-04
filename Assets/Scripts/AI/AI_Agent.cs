using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Agent : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public AI_Worker worker;

    void Start()
    {
        TryGetComponent(out navMeshAgent);
        TryGetComponent(out worker);
    }

}
