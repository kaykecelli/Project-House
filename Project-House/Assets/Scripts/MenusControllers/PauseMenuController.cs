using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenuController : MonoBehaviour
{
    public  bool gameIsPaused = false;
    public GameObject PauseMenuUi;


    // Update is called once per frame
    void Update()
    {
    
    }

    public void Pause(CallbackContext context)
    {
       
        if (context.ReadValue<float>()== 1)
        {
       

            if (gameIsPaused)
            {

                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
       
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
