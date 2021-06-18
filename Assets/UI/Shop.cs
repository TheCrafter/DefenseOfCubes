using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint standardTower;
    public TowerBlueprint missileLauncher;

    BuildManager buildManager;

    private void Start()
    { 
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTower()
    {
        buildManager.TowerToBuild = standardTower;
    }

    public void SelectMissileLauncher()
    {
        buildManager.TowerToBuild = missileLauncher;
    }
}
