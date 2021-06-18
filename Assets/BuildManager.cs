using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;

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

    public Tower StandardTowerPrefab { get { return standardTowerPrefab; } }
    [SerializeField] Tower standardTowerPrefab;

    public Tower MissileLauncherPrefab { get { return missileLauncherPrefab; } }
    [SerializeField] Tower missileLauncherPrefab;

    public TowerBlueprint TowerToBuild {
        get { return towerToBuild; }
        set { towerToBuild = value; }
    }
    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }

    public GameObject BuildTowerOn(Node node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Not enough money to build that tower!");
            return null;
        }

        PlayerStats.Money -= towerToBuild.cost;
        Debug.Log($"Tower built! Money left: {PlayerStats.Money}.");

        return Instantiate(TowerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    }
}
