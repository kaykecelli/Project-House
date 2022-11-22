using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;
public class TomarPilula : MonoBehaviour
{
    [SerializeField]
    string novaCena;

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
    public float quantidadeDePilulas;
   

    private void Start()
    {
        KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();
        ScriptKI.PlacePlayer();
       
       
    }

    public void UsarPilula(CallbackContext context)
    {

        if (context.ReadValue<float>() == 1)
        {
            ScriptKI.SavePosition();
            SceneManager.LoadScene(novaCena);
        }
            
    }
            
        
       
        
        


}
