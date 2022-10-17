using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;
public class TomarPilula : MonoBehaviour
{
    [SerializeField]
    string novaCena;

    public void UsarPilula(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            SceneManager.LoadScene(novaCena);

        }




    }

}
