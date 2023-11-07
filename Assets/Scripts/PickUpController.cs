using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private Transform objectPickUp;
    private bool isPickUp;

    void Start()
    {
        isPickUp = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isPickUp) {
                DropObject();
            } else {
                PickUpObject();
            }
        }
    }

    void PickUpObject () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Quaternion.Euler(0, 30, 0) * transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red, 1f);
        if (Physics.Raycast(ray, out hit, 5f)) {
            if (hit.collider.CompareTag("Pickable")) {
                Debug.Log("Pickable");
                objectPickUp = hit.collider.transform;
                objectPickUp.parent = transform;
                objectPickUp.GetComponent<Rigidbody>().isKinematic = true;
                isPickUp = true;
            }
        }  
    }

    void DropObject () {
        objectPickUp.GetComponent<Rigidbody>().isKinematic = false;
        objectPickUp.parent = null;
        objectPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        objectPickUp = null;
        isPickUp = false;
    }
}
