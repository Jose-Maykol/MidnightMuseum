using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float runningSpeed = 50f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rb;

    private Transform cameraTransform;
    private float rotateSpeed = 1f;
    private float playerRadius = 1.5f;
    private float playerHeight = 3f;

    void Start() {
        rb = GetComponentInChildren<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void Update() {
        Vector2 inputVector = gameInput.GetMomentVectorNormalized();
        bool isRunning = gameInput.IsRunning();
        float speed = isRunning ? runningSpeed : moveSpeed;
        Vector3 moveDirection = cameraTransform.TransformDirection(new Vector3(inputVector.x, 0f, inputVector.y));
        moveDirection.y = 0; // Asegura que no haya movimiento vertical
        rb.velocity = moveDirection.normalized * speed;
    }
}
