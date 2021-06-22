using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;

    public GameObject buildEffect;

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

    public TowerBlueprint TowerToBuild {
        get { return towerToBuild; }
        set { towerToBuild = value; }
    }
    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public GameObject BuildTowerOn(Node node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Not enough money to build that tower!");
            return null;
        }

        PlayerStats.Money -= towerToBuild.cost;
        Debug.Log($"Tower built! Money left: {PlayerStats.Money}.");

        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        return Instantiate(TowerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    }
}
