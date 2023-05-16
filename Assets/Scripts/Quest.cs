using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    
    public bool quete1 = false;
    public bool quete2 = false;
    public bool quete3 = false;
    public GameObject cam;
    public bool camactive = false;
    public GameObject txtquete1 ;
    public GameObject txtquete2;
    public GameObject txtquete3;
    public int quete1kill = 0;
    public int quete2kill = 0;
    public int quete3kill = 0;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        txtquete1.SetActive(quete1);
        txtquete2.SetActive(quete2);
        txtquete3.SetActive(quete3);






        if (Input.GetKeyDown(KeyCode.P))
        {
            cam.SetActive(true);
            
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cam.SetActive(false);
        }



    }

    
}
