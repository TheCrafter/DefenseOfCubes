using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTower()
    {
        buildManager.TowerToBuild = buildManager.StandardTowerPrefab;
    }

    public void PurchaseAnotherTower()
    {
        buildManager.TowerToBuild = buildManager.AnotherTowerPrefab;
    }
}
