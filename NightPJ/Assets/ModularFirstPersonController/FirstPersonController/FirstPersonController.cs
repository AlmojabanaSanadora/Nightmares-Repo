using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    private Rigidbody rb;

    #region Camera Movement Variables

    public Camera playerCamera;

    public float fov = 60f;
    public bool invertCamera = false;
    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;

    // Crosshair
    public bool lockCursor = true;
    public bool crosshair = true;
    public Sprite crosshairImage;
    public Color crosshairColor = Color.white;

    // Internal Variables
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Image crosshairObject;

    #endregion

    #region Movement Variables

    public bool playerCanMove = true;
    public float walkSpeed = 50000000f;

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        crosshairObject = GetComponentInChildren<Image>();

        // Set internal variables
        playerCamera.fieldOfView = fov;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (crosshair)
        {
            crosshairObject.sprite = crosshairImage;
            crosshairObject.color = crosshairColor;
        }
        else
        {
            crosshairObject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        #region Camera

        // Control camera movement
        if (cameraCanMove)
        {
            yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            if (!invertCamera)
            {
                pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                // Inverted Y
                pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
            }

            // Clamp pitch between lookAngle
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            transform.localEulerAngles = new Vector3(0, yaw, 0);
            playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        }

        #endregion
    }

    void FixedUpdate()
    {
        #region Movement

        if (playerCanMove)
{
    // Get input for movement
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    // Calculate movement direction
    Vector3 moveDirection = transform.right * x + transform.forward * z;

    // Apply force for movement
    if (moveDirection.magnitude > 0)
    {
        rb.AddForce(moveDirection.normalized * walkSpeed, ForceMode.Force);
    }

    // Limit the maximum speed to prevent excessive acceleration
    Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    if (horizontalVelocity.magnitude > walkSpeed)
    {
        rb.velocity = horizontalVelocity.normalized * walkSpeed + Vector3.up * rb.velocity.y;
    }
}

        #endregion
    }
}