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
        if (Input.GetMouseButtonDown(0)) {
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
        Debug.DrawRay(transform.position, transform.forward * 8f, Color.red, 1f);
        if (Physics.Raycast(ray, out hit, 8f)) {
            if (hit.collider.CompareTag("Pickable") || hit.collider.CompareTag("key")) {
                Debug.Log("Pickable");
                objectPickUp = hit.collider.transform;
                Collider objectCollider = objectPickUp.GetComponent<Collider>();
                if (objectCollider) {
                    objectCollider.enabled = false;
                }
                objectPickUp.parent = transform;
                objectPickUp.GetComponent<Rigidbody>().isKinematic = true;
                isPickUp = true;
            }
        }  
    }

    void DropObject () {
        Collider objectCollider = objectPickUp.GetComponent<Collider>();
        if (objectCollider) {
            objectCollider.enabled = true;
        }
        objectPickUp.GetComponent<Rigidbody>().isKinematic = false;
        objectPickUp.parent = null;
        objectPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
        objectPickUp = null;
        isPickUp = false;
    }
}
