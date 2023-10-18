using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player; // Asigna el objeto del jugador desde el inspector
    public float speed = 0.01f;
    public float accuracy = 1f;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            this.transform.LookAt(player.position);
            Vector3 directionToPlayer = player.position - this.transform.position;
            Debug.DrawRay(this.transform.position, directionToPlayer, Color.red);

            if (directionToPlayer.magnitude > accuracy)
            {
                // Mueve el objeto
                this.transform.Translate(directionToPlayer.normalized * speed * Time.deltaTime, Space.World);
            }
        }
    }
}
