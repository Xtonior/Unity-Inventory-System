using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Look();
        ControlSpeed();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Look()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
         
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void Move()
    {
        rb.velocity = GetMoveDir() * currentSpeed * Time.fixedDeltaTime;
    }

    private Vector3 GetMoveDir()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        return (transform.forward * ver + transform.right * hor).normalized;
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
