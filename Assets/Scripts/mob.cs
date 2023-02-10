using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mob : MonoBehaviour
{

    
    public Transform[] waypoints;
   
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Destroy(gameObject);
        }


    }

    public Transform[] points;
    public int current;
    public float speed;
    void Start()
    {
        current = 0;
    }


    void Update()
    {
        if (transform.position != waypoints[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % 2;
        }
    }
}


