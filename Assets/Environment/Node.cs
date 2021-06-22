using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.gray;
    [SerializeField] Color invalidColor = Color.red;
    // TODO: Move to tower
    [SerializeField] Vector3 offset = new Vector3(0f, 0.5f, 0f); // TODO: Move to tower

    [HideInInspector] public GameObject tower;
    [HideInInspector] public TowerBlueprint towerBluprint;
    [HideInInspector] public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (tower != null)
        {
            buildManager.SelectedNode = this;
            return;
        }

        if (!buildManager.CanBuild) { return; }

        // Build tower
        BuildTower(buildManager.TowerToBuild);
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that tower!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject tower = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.tower = tower;
        towerBluprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tower built!");
    }

    public void UpgradeTower()
    {
        if (PlayerStats.Money < towerBluprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that tower!");
            return;
        }

        PlayerStats.Money -= towerBluprint.upgradeCost;

        // Get rid of the old tower
        Destroy(this.tower);

        // Build new one
        GameObject tower = Instantiate(towerBluprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.tower = tower;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Tower upgraded!");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (!buildManager.CanBuild) { return; }

        rend.material.color = tower == null && buildManager.HasMoney ? hoverColor : invalidColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }
}
