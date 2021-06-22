using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public float sellPct = .5f;

    public float GetSellCost(bool isUpgraded)
    {
        int totalCost = isUpgraded ? cost + upgradeCost : cost;
        return totalCost * sellPct;
    }
}
