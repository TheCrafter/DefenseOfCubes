using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    void Update()
    {
        moneyText.text = $"${PlayerStats.Money.ToString()}";
    }
}
