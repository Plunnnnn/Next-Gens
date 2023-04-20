using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void play()
    {

        SceneManager.LoadScene("22");
        
        


    }

    public void quit()
    {
        Application.Quit();
    }

}
