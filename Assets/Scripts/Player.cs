using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    private float rotateSpeed = 10f;
    private float playerRadius = 1.5f;
    private float playerHeight = 3f;

    void Update() {
        Vector2 inputVector = gameInput.GetMomentVectorNormalized();
        Vector3 newPos = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, newPos, moveDistance);
        if (canMove) {
            transform.position += newPos * moveSpeed * Time.deltaTime;
        }
        transform.forward = Vector3.Slerp(transform.forward, newPos, Time.deltaTime * rotateSpeed);
    }
}
