using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f; // Adjust this value as needed
    public float sensitivity = 1.0f;
    private float horizontalInput;
    private float forwardInput;
    private float yawX = 0.0f;
    private bool cursorLocked = true;
    private Rigidbody rb; // Reference to the Rigidbody component

    // Crouching
    public float crouchHeight = 0.5f;
    private float defaultHeight = 0.0f;
    private float crouchSpeed = 2.5f;

    void Start()
    {
        // Lock cursor to center of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;

        // Get the reference to the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (PauseMenu.IsPaused()) return;
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

            // Adjust speed
            float currentSpeed = Input.GetKey(KeyCode.LeftControl) ? crouchSpeed : speed;

            // Move the player forward/backward
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed * forwardInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

            // Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            // Rotate the player based on mouse input for yaw (left/right)
            yawX += sensitivity * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0.0f, yawX, 0.0f);

            // Rotate left/right of player
            float targetHeight = Input.GetKey(KeyCode.LeftControl) ? defaultHeight - crouchHeight : defaultHeight;
            Vector3 currentPosition = transform.localPosition;
            transform.localPosition = new Vector3(currentPosition.x, targetHeight, currentPosition.z);
        }
        else
        {
            // Center the mouse cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Jump()
    {
        // Check if the player is grounded before jumping
        if (IsGrounded())
        {
            // Apply upward force to the player
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Perform a ground check using a small sphere
        return Physics.CheckSphere(transform.position - new Vector3(0, GetComponent<Collider>().bounds.extents.y, 0), 0.1f, LayerMask.GetMask("Ground"));
    }
}
