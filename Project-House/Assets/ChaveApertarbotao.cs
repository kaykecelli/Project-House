using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ChaveApertarbotao : MonoBehaviour
{

    
    
    bool colidindo;
    [SerializeField] GameObject imagemChave;



    void Start()
    {

        if (playerController.Instance.ChecarChave(gameObject.name))
        {
            imagemChave.SetActive(true);
            Destroy(gameObject);
        }

        

    }
    public void PegarChave(CallbackContext context)
    {
        
        if (context.ReadValue<float>() == 1 && colidindo == true)
        {
            Destroy(gameObject);
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
