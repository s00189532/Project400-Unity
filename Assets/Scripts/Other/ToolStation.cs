using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolStation : MonoBehaviour
{
    public enum StationType
    {
        Axe,
        Pickaxe,
    }

    public StationType stationType;

    public GameObject PickaxePrefab;
    public GameObject AxePrefab;

    public GameObject ToolPosition;
    GameObject Tool;

    public GameObject BlacksmithPos;
    public GameObject ToolUserPos;

    public bool HasTool = true;

    private void Start()
    {
        SpawnTool();
    }

    public void SpawnTool()
    {
        HasTool = true;

        switch (stationType)
        {
            case StationType.Axe:
                Tool = Instantiate(AxePrefab, ToolPosition.transform.position, Quaternion.identity);
                Tool.transform.parent = ToolPosition.transform;
                break;
            case StationType.Pickaxe:
                Tool = Instantiate(PickaxePrefab, ToolPosition.transform.position, Quaternion.identity);
                Tool.transform.parent = ToolPosition.transform;
                break;
            default:
                break;
        }
    }

    public void DestroyTool()
    {
        HasTool = false;

        if (Tool)
            Destroy(Tool);
    }

}
