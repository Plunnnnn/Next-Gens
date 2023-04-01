using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    //public int respawn;

    //private void ontriggerenter2d(collider2d other)
    //{
    //    if (other.comparetag("player"))
    //    {
    //        scenemanager.loadscene(respawn);      
    //    }
    //}

    // The spawn point for the character
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
            transform.position = spawnPoint.position;
            lastPosition = transform.position;
            Debug.Log("Collision detected at position: " + lastPosition);
        }

        
    }



    

    
}


