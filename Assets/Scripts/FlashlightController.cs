using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform camera;
    public float rotationSpeed = 5f;

    public Light flashlight;

    void Start()
    {
        flashlight.enabled = false;
    }

    void Update()
    {
        if (camera != null)
        {
            Quaternion cameraRotation = camera.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, rotationSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = !flashlight.enabled;
            }

        }
    }
}
