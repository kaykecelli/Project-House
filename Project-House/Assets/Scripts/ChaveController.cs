using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }
}
