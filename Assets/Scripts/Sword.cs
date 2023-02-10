using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    
 
    public Transform pivotPoint;
    CapsuleCollider2D colli;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")
        {
            Debug.Log("kill");
        }

    }


    void Start()


    {
        
        colli = GetComponent<CapsuleCollider2D>();
        colli.enabled = !colli.enabled;
        Debug.Log("Collider.enabled = " + colli.enabled);
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKey(KeyCode.Mouse0))
            {
            StartCoroutine(swing());
                
            }

        

        
    }


    private IEnumerator swing()
    {
        colli.enabled = !colli.enabled;
        pivotPoint.eulerAngles = Vector3.forward * -45;
        yield return new WaitForSeconds(1);
        pivotPoint.eulerAngles = Vector3.forward * -315;
        colli.enabled = !colli.enabled;

    }
    

}
