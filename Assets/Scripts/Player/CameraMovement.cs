using System.Collections;
using System.Collections.Generic;
using GUI;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GuiHandler guiHandler;

    [Header("Settings")]
    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;
    [SerializeField] private float moveSpeed = 100f;

    private float mouseX;
    private float mouseY;

    private float multiplier = 0.01f;

    private float xRotation;
    private float yRotation;

    private float currentSpeed;

    private Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (guiHandler.IsGuiActive()) return;

        Look();
        ControlSpeed();
        HandleInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Look()
    {
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }

    private void Move()
    {
        rb.velocity = GetMoveDir() * currentSpeed * Time.fixedDeltaTime;
    }

    private Vector3 GetMoveDir()
    {
        return (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
    }

    private void ControlSpeed()
    {
        float mul = 0.5f;

        if (GetMoveDir().magnitude != 0.0f)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * mul);

            return;
        }

        currentSpeed = Mathf.Lerp(currentSpeed, 0.0f, Time.deltaTime * mul);
    }
}
