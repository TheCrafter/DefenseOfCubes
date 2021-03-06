using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public TowerBlueprint TowerToBuild
    {
        get { return towerToBuild; }
        set
        {
            towerToBuild = value;
            DeselectNode();
        }
    }
    private TowerBlueprint towerToBuild;

    public Node SelectedNode
    {
        get { return selectedNode; }
        set
        {
            if (selectedNode == value)
            {
                DeselectNode();
            }
            else
            {
                selectedNode = value;
                towerToBuild = null;
                nodeUI.Target = value;
            }
        }
    }
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
