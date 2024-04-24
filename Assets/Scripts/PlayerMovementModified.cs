using UnityEngine;

public class PlayerMovementModified : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 1.0f;
    private float horizontalInput;
    private float forwardInput;
    private float yaw = 0.0f;
    private bool cursorLocked = true;
    private bool isCrouch = false;

    void Start() {
        // Lock cursor to center of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Toggle cursor lock/unlock with the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        // If the cursor is locked, rotate the player based on mouse input
        if (cursorLocked)
        {
            // Get player input
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // Move the player forward/backward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            // Rotate the player based on mouse input
            yaw += sensitivity * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

            // Rotate left/right of player
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        else
        {
            // Center the mouse cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(isCrouch)
            {
                transform.Translate(Vector3.up * 3);
                speed *= 2;
            }
            else
            {
                transform.Translate(Vector3.down * 3);
                speed /= 2;
            }
            isCrouch = !isCrouch;
        }
    }
}
