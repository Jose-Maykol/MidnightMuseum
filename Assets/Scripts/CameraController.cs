using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector2 mouseSensitivity = new Vector2(1, 1); // Sensibilidad del mouse

    public Transform orientation; // Orientación de la cámara

    float xRotation; // Rotación en el eje X
    float yRotation; // Rotación en el eje Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor
        Cursor.visible = false; // Oculta el cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime; // Obtiene el movimiento del mouse en el eje X
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime; // Obtiene el movimiento del mouse en el eje Y

        yRotation += mouseX; // Incrementa la rotación en el eje Y
        xRotation -= mouseY; // Incrementa la rotación en el eje X
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación en el eje X

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // Aplica la rotación a la cámara
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // Aplica la rotación a la orientación
    }
}
