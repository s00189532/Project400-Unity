using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Worker : MonoBehaviour
{
    public enum AIRole
    {
        Miner,
        Lumberjack,
    }

    public AIRole role = AIRole.Miner;

    public bool HasTool = true;
    public float ToolDurability = 100;

    public float IronCollected = 0;
    public float WoodCollected = 0;

    [HideInInspector] public GameObject Tool;
    public GameObject ToolPosition;

    public GameObject AxePrefab;
    public GameObject PickaxePrefab;

    [HideInInspector] public Storage storage;

    [HideInInspector] public Vector3 woodPos;
    [HideInInspector] public Vector3 ironPos;

    private void Start()
    {
        AssignTool();

        storage = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();

        woodPos = GameObject.FindGameObjectWithTag("WoodPosition").transform.position;
        ironPos = GameObject.FindGameObjectWithTag("IronPosition").transform.position;
    }

    void AssignTool()
    {
        switch (role)
        {
            case AIRole.Miner:
                Tool = Instantiate(PickaxePrefab, ToolPosition.transform.position, Quaternion.identity);
                break;
            case AIRole.Lumberjack:
                Tool = Instantiate(AxePrefab, ToolPosition.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

        if (Tool != null)
            Tool.transform.parent = ToolPosition.transform;

        ToolPosition.transform.Rotate(30, 0, 0);
    }

    public void HideTool()
    {
        HasTool = false;

        if (Tool != null)
            Destroy(Tool);
    }

    public void ShowTool()
    {
        ToolDurability = 100;
        HasTool = true;
        AssignTool();
    }
}
