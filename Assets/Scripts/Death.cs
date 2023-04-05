using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    public Player player;
    public Transform spawnPoint;
    public Transform[] waypoints;
    private Transform TP;
    Vector3 lastPosition;
    // Detect when the character collides with an object tagged "Respawn"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mort"))
        {
            // Move the character back to its spawn point
            respawn();
            Debug.Log("Collision detected at position: " + lastPosition);
        }

        
    }

    public void respawn()
    {
        transform.position = spawnPoint.position;
        lastPosition = transform.position;
        
    }

    

    
}


