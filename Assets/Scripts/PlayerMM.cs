using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMM : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed = 5f;
    private bool stopMove = false;

    [Header("Jump")] 
    public float jumpTimer = 0f;
    public float maxJumpTime = 4f;
    public float maxJump = 25f;
    public float jumpForce;
    
    bool readyToJump;
    
    [Header("Ground Check")]
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    public Transform PlayerObj;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Jump();
        
    }

    void GroundCheck()
    {
        grounded = Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance,
            whatIsGround);
        Debug.Log(grounded);
        if (grounded == false)
        {
            stopMove = true;
        }

        if (grounded && readyToJump == false)
        {
            stopMove = false;
        }
    }

    void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log($"Stop move : {stopMove} ");
        if (stopMove == false)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed , ForceMode.Force);
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if(flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded )
        {
            readyToJump = true;
            stopMove = true;
        }

        if (Input.GetKey(KeyCode.Space) && grounded && readyToJump)
        {
            stopMove = true;
            jumpTimer += Time.deltaTime;
            if (jumpTimer > maxJumpTime)
            {
                jumpTimer = maxJumpTime;
            }

            jumpForce = (jumpTimer / maxJumpTime) * maxJump;
            jumpForce = Mathf.Clamp(jumpForce, jumpForce / 4, jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && grounded && readyToJump)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(PlayerObj.forward * (jumpForce/2), ForceMode.Impulse);
            readyToJump = false;
            jumpTimer = 0;
            jumpForce = 0;
            stopMove = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance,boxSize);
    }
}
