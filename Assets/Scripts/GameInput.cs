using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector2 GetMomentVectorNormalized() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("Adelante");
            inputVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("Atras");
            inputVector.y -= 1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Izquierda");
            inputVector.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Derecha");
            inputVector.x += 1f;
        }
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
