using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float sensitivity = 1.0f;
    private float verticalRotation = 0.0f;
    private float maxVerticalRotation = 90.0f;

    void LateUpdate()
    {
        // Update verticalRotation (up/down rotation) based on mouse input
        verticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalRotation, maxVerticalRotation); // Clamp verticalRotation angle

        // Calculate rotation quaternion for vertical rotation only
        Quaternion rotation = Quaternion.Euler(verticalRotation, player.transform.eulerAngles.y, 0);

        // Set camera position and rotation relative to player
        transform.position = player.transform.position + offset;
        transform.rotation = rotation;
    }
}