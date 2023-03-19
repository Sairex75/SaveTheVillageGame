using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool paused;
    public GameObject PauseMenu;
  

    public void PauseGame()
    {
       

        if (paused)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
           
        }
        else
        {
           
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
           
        }

        paused = !paused;
    }
    
}
