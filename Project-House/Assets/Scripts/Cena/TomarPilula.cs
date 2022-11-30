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
    char c, cAtual;
    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
    public playerController playerController;
    string CenaAtual;
    Scene currentScene;


  


    private void Start()
    {
        KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();
        ScriptKI.PlacePlayer();
      

    }

    private void Update()
    {
        TrocarNome();
    }





    void TrocarNome()
    {

        currentScene = SceneManager.GetActiveScene();
        CenaAtual = currentScene.name;
        novaCena = CenaAtual;
        c = novaCena[novaCena.Length - 1];

        if (c == '2')
        {
           
            novaCena = novaCena.Substring(0, novaCena.Length - 1) + "1";
         
        }
        
       
        if(c == '1')
        {
            novaCena = novaCena.Substring(0, novaCena.Length - 1) + "2";
        }
        
        
    }
           

    

    public void UsarPilula(CallbackContext context)
    {
   


        if (context.ReadValue<float>() == 1 && c == '2')
        {
            Debug.Log("mudou");
            playerController.quantidadeDePilulas -= 1;
            ScriptKI.SavePosition();
            SceneManager.LoadScene(novaCena);
           

        }
        else
        {
            ScriptKI.SavePosition();
            SceneManager.LoadScene(novaCena);
            
        }
    }
            

            


           
       

       

    








}
