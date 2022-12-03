using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ChaveApertarbotao : MonoBehaviour
{

    public GameObject itemImage;

    bool colidindo;
    



    void Start()
    {

        if (playerController.Instance.ChecarChave(gameObject.name))
        {
            
            Destroy(gameObject);
        }

        

    }
    public void PegarChave(CallbackContext context)
    {

        if (context.ReadValue<float>() == 1 && colidindo == true)
        {
            for (int i = 0; i < playerController.Instance.slots.Length; i++)
            {
                if (playerController.Instance.isFull[i] == false)
                {
                    playerController.Instance.isFull[i] = true;
                    Instantiate(itemImage, playerController.Instance.slots[i].transform, false);
                    Destroy(gameObject);
                    break;

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colidindo = true;

        }
        else
        {
            colidindo=false;
        }


    }
}
