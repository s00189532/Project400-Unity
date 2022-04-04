using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 moveToPosition;

    public GameObject pos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        PickRandomPosition();
        agent.SetDestination(pos.transform.position);
    }

    /*void Update()
    {
        if (Vector3.Distance(transform.position, moveToPosition) <= 0.1f)
        {
            PickRandomPosition();
        }
        else
            Debug.Log("moving");
    }*/

    public void MoveTo(Vector3 position)
    {
        moveToPosition = position;
        agent.SetDestination(moveToPosition);
    }

    void PickRandomPosition()
    {
        int posX = Random.Range(-100, 100);
        int posZ = Random.Range(-100, 100);

        Vector3 pos = new Vector3(posX, transform.position.y, posZ);

        Debug.Log("moveToPosition = " + pos);
        MoveTo(pos);
    }
}
