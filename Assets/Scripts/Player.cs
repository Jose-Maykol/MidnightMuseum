using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 7f;
    void Update() {
        Vector2 pos = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("Adelante");
            pos.y += 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("Atras");
            pos.y -= 1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Izquierda");
            pos.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Derecha");
            pos.x += 1f;
        }
        pos = pos.normalized;

        Vector3 newPos = new Vector3(pos.x, 0f, pos.y);
        transform.position += newPos * moveSpeed * Time.deltaTime;
    }
}
