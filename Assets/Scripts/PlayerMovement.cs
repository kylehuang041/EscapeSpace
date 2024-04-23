using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 1.0f;
    private float horizontalInput;
    private float forwardInput;
    private float yaw = 0.0f;

    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward/backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotate the player based on mouse input
        yaw += sensitivity * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        // Rotate left/right of vehicle
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
    }
}
