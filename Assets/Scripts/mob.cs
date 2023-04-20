using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using TMPro;
public class mob : MonoBehaviour
{

    Quest quest;

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

  

    public TMP_Text quete1txt;
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
            Vector3 localScale = transform.localScale;
            
            localScale.x *= -1f;
            transform.localScale = localScale;
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

            if (quest.quete1kill <= 5 ) ;
            {

                quest.quete1kill += 1;
                
               quete1txt.text = "Quete 1 : tuer 5 zombies :" + quest.quete1kill.ToString() + "/5" ;
            }
        }
    
    
    }

    private void OnDrawGizmosSelected()
    {
        if (range == null)
            return;

        
    }


}


