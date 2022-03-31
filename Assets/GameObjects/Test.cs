using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 moveToPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        PickRandomPosition();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, moveToPosition) <= 0.1f)
        {
            PickRandomPosition();
        }
        else
            Debug.Log("moving");
    }

    public void MoveTo(Vector3 position)
    {
        moveToPosition = position;
        agent.SetDestination(moveToPosition);
    }

    void PickRandomPosition()
    {
        int posX = Random.Range(-200, 200);
        int posZ = Random.Range(-200, 200);

        Vector3 pos = new Vector3(posX, transform.position.y, posZ);

        Debug.Log("moveToPosition = " + pos);
        MoveTo(pos);
    }
}
