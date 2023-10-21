using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float runningSpeed = 50f;
    [SerializeField] private GameInput gameInput;
    private float rotateSpeed = 10f;
    private float playerRadius = 1.5f;
    private float playerHeight = 3f;

    void Update() {
        Vector2 inputVector = gameInput.GetMomentVectorNormalized();
        bool isRunning = gameInput.IsRunning();
        float speed = isRunning ? runningSpeed : moveSpeed;
        Vector3 newPos = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = speed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, newPos, moveDistance);
        if (canMove) {
            transform.position += newPos * speed * Time.deltaTime;
        }
        transform.forward = Vector3.Slerp(transform.forward, newPos, Time.deltaTime * rotateSpeed);
    }
}
