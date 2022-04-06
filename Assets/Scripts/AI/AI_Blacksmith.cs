using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Blacksmith : MonoBehaviour
{
    [HideInInspector] public Storage storage;
    [HideInInspector] public Anvil anvil;

    public float IronCollected = 0;
    public float WoodCollected = 0;

    public bool hasPickaxe = false;
    public bool hasAxe = false;

    public bool atAnvil = false;

    private void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();
        anvil = GameObject.FindGameObjectWithTag("Anvil").GetComponent<Anvil>();
    }

    private void Update()
    {
        Vector3 distanceToTarget = transform.position - anvil.BlacksmithPosition.transform.position;
        distanceToTarget.y = 0;

        if (distanceToTarget.magnitude <= 0.1f)
            atAnvil = true;
        else
            atAnvil = false;
    }
}
