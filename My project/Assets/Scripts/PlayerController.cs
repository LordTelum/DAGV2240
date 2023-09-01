using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private int availableJumps; // Track the remaining jumps

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        availableJumps = 2; // Initialize available jumps to 2 (double jump)
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(0, 0, moveInput);
        Vector3 move = transform.TransformDirection(moveDirection) * moveSpeed;

        // Apply gravity
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;

            // Reset available jumps when grounded
            availableJumps = 2;
        }

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || availableJumps > 0)
            {
                if (!isGrounded)
                {
                    availableJumps--; // Decrement available jumps if double jumping
                }

                velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
            }
        }

        // Apply movement and gravity
        controller.Move((move + velocity) * Time.deltaTime);
    }
}