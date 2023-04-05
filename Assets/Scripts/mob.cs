using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class mob : MonoBehaviour
{

    
    public Transform[] waypoints;
    
    public int maxHP = 100;
    int HP;
    


   

    public Transform[] points;
    public int current;
    public float speed;
    void Start()
    {
        current = 0;
        HP = maxHP;
        
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
    public void touche(int degats)
    {
        HP -= degats;
    
        if (HP <= 0 )
        {
            
            Destroy(gameObject);
        }
    
    
    }

    


}


