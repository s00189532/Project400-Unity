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

    [HideInInspector] public Storage storage;
    [HideInInspector] public Anvil anvil;

    [HideInInspector] public Vector3 woodPos;
    [HideInInspector] public Vector3 ironPos;

    private void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();
        anvil = GameObject.FindGameObjectWithTag("Anvil").GetComponent<Anvil>();

        woodPos = GameObject.FindGameObjectWithTag("WoodPosition").transform.position;
        ironPos = GameObject.FindGameObjectWithTag("IronPosition").transform.position;
    }

    public void HarvestResource()
    {
        UseTool();

        if(role == AIRole.Miner)
        {
            IronCollected++;
        }
        else if(role == AIRole.Lumberjack)
        {
            WoodCollected++;
        }
    }

    public void DepositResources()
    {
        storage.StoreIron(IronCollected);
        IronCollected = 0;

        storage.StoreWood(WoodCollected);
        WoodCollected = 0;
    }

    void UseTool()
    {
        ToolDurability -= 10;

        if (ToolDurability <= 0)
        {
            HasTool = false;
        }
    }

    public void GetTool()
    {
        HasTool = true;
        ToolDurability = 100;
    }
}
