using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{


    Player player;
    public int points;




    private void Start()        // Start is called before the first frame update
    {
        
        player = FindObjectOfType<Player>();
    
    }

    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score1.instance.IncreaseCoins();
            Destroy(gameObject);
            

            


        }


    }

 
}
