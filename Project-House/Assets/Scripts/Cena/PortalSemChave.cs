using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSemChave : MonoBehaviour
{
    [SerializeField]
    string novaCena;

    GameObject KeepInfo;
    SavePositionPlayer ScriptKI;

    private void Start()
    {
        KeepInfo = GameObject.FindGameObjectWithTag("KEEPINFO");
        ScriptKI = KeepInfo.GetComponent<SavePositionPlayer>();


        ScriptKI.PlacePlayer();
    }
    public void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {

            SceneManager.LoadScene(novaCena);
            ScriptKI.SavePosition();
        }
        
    }
}
