using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.gray;
    [SerializeField] Color invalidColor = Color.red;
    // TODO: Move to tower
    [SerializeField] Vector3 offset = new Vector3(0f, 0.5f, 0f); // TODO: Move to tower

    [Header("Optional")]
    public GameObject tower;

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
        if (BuildTower())
        {
            rend.material.color = invalidColor;
        }
    }

   
    bool BuildTower()
    {
        tower = buildManager.BuildTowerOn(this);
        return tower != null;
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
