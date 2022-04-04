using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Worker: MonoBehaviour
{
    public enum AIRole
    {
        Miner,
        Lumberjack,
        BlackSmith,
    }

    public AIRole role = AIRole.Miner;

    public bool HasTool = true;
    public float ToolDurability = 100;

    public float IronCollected = 0;
    public float WoodCollected = 0;

    public GameObject ToolPosition;
    public GameObject TestTool;

    [HideInInspector] public Storage storage;
    [HideInInspector] public Anvil anvil;

    [HideInInspector] public Vector3 woodPos;
    [HideInInspector] public Vector3 ironPos;

    private void Start()
    {
        GameObject go = Instantiate(TestTool, ToolPosition.transform.position, Quaternion.identity);
        go.transform.parent = ToolPosition.transform;
        ToolPosition.transform.Rotate(30, 0, 0);

        storage = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();
        anvil = GameObject.FindGameObjectWithTag("Anvil").GetComponent<Anvil>();

        woodPos = GameObject.FindGameObjectWithTag("WoodPosition").transform.position;
        ironPos = GameObject.FindGameObjectWithTag("IronPosition").transform.position;
    }
}
