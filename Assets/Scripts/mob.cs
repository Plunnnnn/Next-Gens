using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class mob : MonoBehaviour
{

    
    public Transform[] waypoints;
    
    public int maxHP = 100;
    int HP;
    public Player player;


   

    public Transform[] points;
    public int current;
    public float speed;

    public Transform range;
    public Vector2 taille;
    public CapsuleDirection2D direction;
    [SerializeField] private float attackrange = 1.5f;
  


    void Start()
    
    
    
    
    {
        taille =  new Vector2(1f, 2f);
        direction = new CapsuleDirection2D();

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

        Physics2D.OverlapCapsuleAll(range.position, taille, direction, 1.0f);
    }
    public void touche(int degats)
    {
        player.KB = player.KBTemps;
        HP -= degats;
        if(player.isFacingRight == true) 
        {
            player.isFacingRight = true;
        }
        if (player.isFacingRight == false)
        {
            player.isFacingRight = false;
        }

        if (HP <= 0 )
        {
            
            Destroy(gameObject);
        }
    
    
    }

    private void OnDrawGizmosSelected()
    {
        if (range == null)
            return;

        
    }


}


