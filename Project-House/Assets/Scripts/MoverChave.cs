using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverChave : MonoBehaviour
{

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
    

   
    void Start()
    {
       
        if (playerController.Instance.ChecarChave(gameObject.name))
        {
           
            Destroy(gameObject);
        }
        
            KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();
       

        

       


        ScriptKI.PlacePlayer();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = transform.position + new Vector3(500f, 500f);
            ScriptKI.SavePosition();
           
        }


    }
}
