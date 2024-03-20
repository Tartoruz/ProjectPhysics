using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    public float groundDrag = 1f;

    public float jumpTimer = 0f;
    public float jumpForce = 0f;
    public float jumpHighest = 25f;
    public float jumpCooldown = 1f;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {   
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

private void FixedUpdate()
{
    MovePlayer();
}

private void MyInput()
{
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    // when to jump
    if(Input.GetKey(jumpKey) && readyToJump && grounded)
    {
        readyToJump = false;
        jumpTimer += Time.deltaTime;
        Jump(jumpTimer);

        Invoke(nameof(ResetJump), jumpCooldown);
    }
}

private void MovePlayer()
{
    // calculate movement direction
    moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

    // on ground
    if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    // in air
    else if(!grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
}

private void SpeedControl()
{
    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    // limit velocity if needed
    if(flatVel.magnitude > moveSpeed)
    {
        Vector3 limitedVel = flatVel.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    }
}

private void Jump(float jumpTime)
{
    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
}
private void ResetJump()
{
    readyToJump = true;
}
}
