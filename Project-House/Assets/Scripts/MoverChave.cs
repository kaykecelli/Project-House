using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverChave : MonoBehaviour
{

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
  
    public GameObject itemImage;
    

   
    void Start()
    {
        // se estiver com chave
        if (playerController.Instance.ChecarChave(gameObject.name))
        {
            // destrói chave do cenário
            Destroy(gameObject);
        }
        
          

    }
    // se está perto de porta trancada
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < playerController.Instance.slots.Length; i++)
            {
                if (playerController.Instance.isFull[i] == false)
                {   
                    // usar chave
                    playerController.Instance.isFull[i] = true;
                    Instantiate(itemImage, playerController.Instance.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                    
                }
            }
           
        }


    }
}
