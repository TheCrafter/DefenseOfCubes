using UnityEngine;

public class CameraController : MonoBehaviour
{
    // TODO: Check this out -> https://forum.unity.com/threads/rts-camera-script.72045/

    [SerializeField] float panSpeed = 30f;
    [SerializeField] float scrollSpeed = 5f;
    [SerializeField] float panBorderThickness = 10f;
    [SerializeField] float minY = 10f;
    [SerializeField] float maxY = 80f;

    [SerializeField] bool mouseMovement = false;

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        // Handle movement input
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey("w") || (mouseMovement && Input.mousePosition.y >= Screen.height - panBorderThickness))
        {
            moveVector = Vector3.forward;
        }
        if (Input.GetKey("s") || (mouseMovement && Input.mousePosition.y <= panBorderThickness))
        {
            moveVector = Vector3.back;
        }
        if (Input.GetKey("d") || (mouseMovement && Input.mousePosition.x >= Screen.width - panBorderThickness))
        {
            moveVector = Vector3.right;
        } 
        if (Input.GetKey("a") || (mouseMovement && Input.mousePosition.x <= panBorderThickness))
        {
            moveVector = Vector3.left;
        }

        // Move
        transform.Translate(moveVector * panSpeed * Time.deltaTime, Space.World);

        // Scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
