using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Node Target
    {
        get { return target; }
        set
        {
            target = value;
            transform.position = target.GetBuildPosition();
            ui.SetActive(true);
        }
    }
    private Node target;

    public void Hide()
    {
        ui.SetActive(false);
    }
}
