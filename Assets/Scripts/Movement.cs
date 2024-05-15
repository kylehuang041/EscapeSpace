using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    private bool cursorLocked = true;

    Vector3 moveDirection;

    Rigidbody rb;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        if (PauseMenu.IsPaused()) return;
        // Toggle cursor lock/unlock with the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        MyInput();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
