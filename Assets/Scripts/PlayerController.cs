using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    [Header("Camera")]
    public Transform camera;

    [Header("Movement")]
    public float runningSpeed = 50f;
    public float walkingSpeed = 25f;
    private float moveSpeed;

    [Header("Jump")]
    public float jumpForce = 5f;
    public float jumpColdDown = 0.25f;
    public float airMultiplier = 0.4f;

    [Header("Ground")]
    public LayerMask Ground;
    bool isGrounded;
    public float groundDrag = 6f;
    public float playerHeight = 2f;
    
    bool readyToJump;

    [Header("Other")]
    public Transform orientation;
    public Transform pickUpObject;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    private Rigidbody rb;

    private State state;

    public enum State {
        Normal,
        Running,
        Jumping
    }

    private void Start() {
        rb = GetComponentInChildren<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = walkingSpeed;
        readyToJump = true;
        state = State.Normal;
    }

    private void Update() {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.2f, Ground);
        Inputs();
        SpeedControl();
        HandlerState();
        
        if (isGrounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = 0f;
        }

        RotatePlayer();
    }

    private void FixedUpdate() {
        Move();
    }

    private void HandlerState() {
        if (isGrounded && Input.GetKey(runKey)) {
            state = State.Running;
            moveSpeed = runningSpeed;
        } else if (isGrounded && Input.GetKey(jumpKey)) {
            state = State.Jumping;
        } else {
            state = State.Normal;
            moveSpeed = walkingSpeed;
        }
    }

    private void Inputs() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space) && isGrounded && readyToJump) {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpColdDown);
        }
    }

    private void Move() {
        if (horizontalInput != 0 || verticalInput != 0) {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        if (isGrounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVelocity.magnitude > moveSpeed) {
            Vector3 newVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        readyToJump = true;
    }

    private void RotatePlayer() {
        Vector3 cameraForward = camera.transform.forward;
        pickUpObject.transform.forward = cameraForward.normalized;
        cameraForward.y = 0f;
        transform.forward = cameraForward.normalized;
    }
}
