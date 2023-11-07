using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostNavMeshController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private bool isHit = false;
    private float hitTime = 0f;
    private float hitDuration = 3f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
    void Update()
    {
        if (isHit)
        {
            hitTime += Time.deltaTime;
            if (hitTime >= hitDuration)
            {
                isHit = false;
                hitTime = 0f;
                rb.isKinematic = false;
                navMeshAgent.enabled = true;
            }
        } else {
            if (player != null)
            {
                navMeshAgent.SetDestination(player.position);
            } 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            Debug.Log("Ghost hit");
            if (!isHit)
            {
                isHit = true;
                rb.isKinematic = true;
                navMeshAgent.enabled = false;
                Vector3 newPosition = transform.position;
                newPosition.y = 0f;
                transform.position = newPosition;
            }
        }
    }
}
