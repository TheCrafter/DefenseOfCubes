using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Button upgradeButton;
    public Text upgradeCost;
    public Text sellCost;

    public Node Target
    {
        get { return target; }
        set
        {
            target = value;
            transform.position = target.GetBuildPosition();
            ui.SetActive(true);

            if (target.isUpgraded)
            {
                upgradeCost.text = $"DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCost.text = $"${target.towerBluprint.upgradeCost}";
                upgradeButton.interactable = true;
            }

            sellCost.text = $"${target.towerBluprint.GetSellCost(target.isUpgraded)}";
        }
    }
    private Node target;

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }
}
