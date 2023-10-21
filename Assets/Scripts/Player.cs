using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float runningSpeed = 50f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rb;
    private float rotateSpeed = 1f;
    private float playerRadius = 1.5f;
    private float playerHeight = 3f;

    void Start() {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update() {
        Vector2 inputVector = gameInput.GetMomentVectorNormalized();
        bool isRunning = gameInput.IsRunning();
        float speed = isRunning ? runningSpeed : moveSpeed;
        // Calcular la dirección del movimiento
            Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

            // Aplicar la velocidad al Rigidbody
            rb.velocity = moveDirection.normalized * speed;
    }
}
