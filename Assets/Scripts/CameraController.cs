using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform camera;
    public Vector2 mouseSensitivity = new Vector2(1, 1); // Sensibilidad del mouse

    void Start()
    {
        camera = transform.Find("Camera"); // Obtiene la cámara
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Obtiene el movimiento del mouse en el eje X
        float mouseY = Input.GetAxis("Mouse Y"); // Obtiene el movimiento del mouse en el eje Y

        if (mouseX != 0) // Si el mouse se movió
        {
            transform.Rotate(Vector3.up * mouseX * mouseSensitivity.x); // Rota la cámara
        }
        if (mouseY != 0) // Si el mouse se movió
        {
            float angle = (camera.localEulerAngles.x - mouseY * mouseSensitivity.y + 360) % 360; // Obtiene el ángulo de la cámara
            if (angle > 180) angle -= 360; // Si el ángulo es mayor a 180, lo convierte a negativo
            angle = Mathf.Clamp(angle, -80, 80); // Limita el ángulo de la cámara
            camera.localEulerAngles = Vector3.right * angle; // Rota la cámara
        }
    }
}
