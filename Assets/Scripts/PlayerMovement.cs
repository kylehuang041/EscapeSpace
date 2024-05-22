using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private float speedBoost;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    private bool cursorLocked;
    private bool isRunning = false;

    Vector3 moveDirection;

    Rigidbody rb;

    void Awake()
    {
        speedBoost = moveSpeed * 1.25f;
    }

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cursorLocked = true;
        Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        float tempSpeed = (isRunning ? speedBoost : moveSpeed);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * tempSpeed * 10f, ForceMode.Force);
        transform.rotation = orientation.rotation;
    }
}