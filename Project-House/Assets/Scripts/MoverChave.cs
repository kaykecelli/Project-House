using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverChave : MonoBehaviour
{

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;

    private void Awake()
    {
        GameObject[] gObjetos = GameObject.FindGameObjectsWithTag("ChavePrincipal");
        if (gObjetos.Length > 1)
        {
            
            Destroy(gameObject.transform.parent.gameObject);
            //valido apenas para o player como primeiro filho
           
        }
    }
    void Start()
    {
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
