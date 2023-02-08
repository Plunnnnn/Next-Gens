using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class fallingRock : MonoBehaviour
{
    private int go;
    private Rigidbody2D rock;
    private Rigidbody2D detectionCollider;
    private bool isUp;
    [SerializeField]private Collider2D detecteur;
    private float hArret;

    private float Y;



    // Start is called before the first frame update
    void Start()
    {


        detectionCollider = GetComponent<Rigidbody2D>();
        rock = GetComponent<Rigidbody2D>();
        go = 0;
        isUp = true;
    }


    // Update is called once per frame
    private void Update()
    {



         
        Y = rock.transform.position.y;
        hArret = Y + 7;


    }



    private IEnumerator fall() // enumeration de pseudo-fonctions
    {
            Debug.Log("go");

            rock.gravityScale = 4f;
            
            yield return new WaitForSeconds(2);

            rock.gravityScale = 0f;

            

           
            
            while ( Y < hArret )
            {

                transform.Translate(Vector2.up * Time.deltaTime);
                yield return new WaitForSeconds(1 / 1000);
                Y = rock.transform.position.y;

            }

            yield return new WaitForSeconds(2);

            isUp = true;






    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isUp == true)
        {

            Debug.Log("touché");
            StartCoroutine(fall());
            isUp = false;


        }




    }
    
    




    





}
