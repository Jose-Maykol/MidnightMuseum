using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostNavMeshController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private bool isHit;
    private float hitTime = 0f;
    private float hitDuration = 3f;
    private Vector3 initialPosition;

    public LevelLoader levelLoader;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        isHit = true;
        initialPosition = transform.position;
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
        Debug.Log("Trigger " + other.tag);
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
                Destroy(other.gameObject);
            } 
        } else if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            transform.position = initialPosition;
            isHit = true;
            levelLoader.ReloadLevel();
        }
    }
}
