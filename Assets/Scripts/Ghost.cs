using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Player")]
    public Transform player; // Asigna el objeto del jugador desde el inspector

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
    private void Start()
    {
        timer = wanderTimer;
        speed = walkingSpeed;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - this.transform.position;
            
            if (directionToPlayer.magnitude > 100f) {
                speed = walkingSpeed;
                Debug.DrawRay(transform.position, transform.forward * wanderRadius, Color.red);
                Wander();
            } else {
                Debug.DrawRay(this.transform.position, directionToPlayer, Color.red);
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

            // Asegúrate de que el enemigo no se eleve por encima o por debajo del terreno
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
}
