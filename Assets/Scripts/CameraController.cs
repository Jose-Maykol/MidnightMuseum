using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Objetivo de la cámara
    public Vector2 mouseSensitivity = new Vector2(1, 1); // Sensibilidad del mouse

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = newPosition; // Iguala la posición de la cámara a la del objetivo

        float mouseX = Input.GetAxis("Mouse X"); // Obtiene el movimiento del mouse en el eje X
        float mouseY = Input.GetAxis("Mouse Y"); // Obtiene el movimiento del mouse en el eje Y

        if (mouseX != 0) // Si el mouse se movió
        {
            transform.Rotate(Vector3.up * mouseX * mouseSensitivity.x); // Rota la cámara
        }
        if (mouseY != 0) // Si el mouse se movió
        {   
            Vector3 rotation = transform.localEulerAngles; // Obtiene la rotación de la cámara
            rotation.x = (rotation.x - mouseY * mouseSensitivity.y + 360) % 360; // Obtiene el ángulo de la cámara
            if (rotation.x > 80 && rotation.x < 180) // Si el ángulo es mayor a 80 y menor a 180
            {
                rotation.x = 80; // El ángulo es 80
            }
            else if (rotation.x < 280 && rotation.x > 180) // Si el ángulo es menor a 280 y mayor a 180
            {
                rotation.x = 280; // El ángulo es 280
            }
            transform.localEulerAngles = rotation; // Aplica la rotación a la cámara
        }
    }
}
