using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15.0f;
    public float terminalVelocity = -20.0f;
    private float vertSpeed;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        // Check if the character is on the ground
        if (charController.isGrounded)
        {
            vertSpeed = -0.1f;  // slight downward force to keep character grounded

            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
            }
        }
        else
        {
            // Apply gravity over time if not grounded
            vertSpeed += gravity * Time.deltaTime;
            // Clamp vertical speed to terminal velocity
            vertSpeed = Mathf.Clamp(vertSpeed, terminalVelocity, jumpSpeed);
        }

        movement.y = vertSpeed;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
