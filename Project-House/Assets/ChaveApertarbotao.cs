using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ChaveApertarbotao : MonoBehaviour
{

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;
    bool colidindo;



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
    public void PegarChave(CallbackContext context)
    {
        
        if (context.ReadValue<float>() == 1 && colidindo == true)
            {
            transform.position = transform.position + new Vector3(500f, 500f);
            ScriptKI.SavePosition();
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
