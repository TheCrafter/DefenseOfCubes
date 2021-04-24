using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.gray;
    [SerializeField] Color invalidColor = Color.red;

    private Tower tower;

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
        if (buildManager.TowerToBuild == null) { return; }

        if (tower != null)
        {
            Debug.Log("Cannot build there! - TODO: Display on screen."); // TODO: Remove
        }
        else
        {
            // Build tower
            BuildTower();

            rend.material.color = invalidColor;
        }
    }

    // TODO: Move to tower
    [SerializeField] Vector3 offset = new Vector3(0f, 0.5f, 0f); // TODO: Move to tower
    void BuildTower()
    {
        Tower towerToBuild = buildManager.TowerToBuild;
        tower = Instantiate(towerToBuild, transform.position + offset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (buildManager.TowerToBuild == null) { return; }

        rend.material.color = tower == null ? hoverColor : invalidColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
