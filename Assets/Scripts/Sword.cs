using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Mob")
        {
            Debug.Log("kill");        
        }

    }


    void Start()
    
    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}