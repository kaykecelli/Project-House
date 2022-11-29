using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamarDeVolta : MonoBehaviour
{
    public SimpleFollow simpleFollow;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerController.Instance.ChecarChave(gameObject.name))
        {
            simpleFollow.Voltar();
        }
    }
}
