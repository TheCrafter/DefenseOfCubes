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

    [SerializeField] Tower standardTowerPrefab;

    public Tower TowerToBuild { get { return towerToBuild; } }
    private Tower towerToBuild;

    private void Start()
    {
        towerToBuild = standardTowerPrefab;
    }
}
