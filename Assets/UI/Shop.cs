using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint standardTower;
    public TowerBlueprint missileLauncher;
    public TowerBlueprint laserBeamer;

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

    public void SelectLaserBeamer()
    {
        buildManager.TowerToBuild = laserBeamer;
    }
}
