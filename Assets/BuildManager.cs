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

    public Tower TowerToBuild {
        get { return towerToBuild; }
        set { towerToBuild = value; }
    }
    private Tower towerToBuild;
}
