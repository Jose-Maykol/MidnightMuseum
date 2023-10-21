using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float rotationScale = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * rotationScale, 0, 0);
    }
}
