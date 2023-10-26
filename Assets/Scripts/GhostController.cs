using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Waypoints")]
    public GameObject[] waypoints;
    private int currentWP = 0;

    [Header("Movement")]
    private float speed;
    public float walkingSpeed = 7f;
    public float runningSpeed = 10f;
    public float accuracy = 0.01f;

    [Header("Wandering")]
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;

    private float timer;
    private Vector3 randomDirection;

    private bool playerFound;

    private void Start()
    {
        timer = wanderTimer;
        speed = walkingSpeed;
        playerFound = false;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - this.transform.position;
            if (directionToPlayer.magnitude > 100f) {
                speed = walkingSpeed;
                Debug.DrawRay(this.transform.position, transform.forward, Color.red, 11f);
                if (playerFound == true) {
                    MoveToWaypoint();
                } else {
                    Wander();
                }
            } else {
                playerFound = true;
                Debug.DrawRay(this.transform.position, directionToPlayer, Color.red, 11f);
                speed = runningSpeed;
                Seeking();
            }
        }
    }

    private void Wander() {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;
            randomDirection.y = transform.position.y;
            transform.LookAt(randomDirection);
            timer = 0;
        }

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    private void Seeking() {
        Vector3 directionToPlayer = player.position - this.transform.position;
        // Calcula la dirección hacia el jugador
        this.transform.LookAt(player.position);
        // Si la distancia es mayor que la precisión, mueve el objeto
        if (directionToPlayer.magnitude > accuracy)
        {
            // Mueve el objeto
            this.transform.Translate(directionToPlayer.normalized * speed * Time.deltaTime, Space.World);
        } else if (directionToPlayer.magnitude < accuracy) {
            // Si no, detente
            this.transform.Translate(Vector3.zero);
        }
    }

    private void MoveToWaypoint() {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, 30f * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
