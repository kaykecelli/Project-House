using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCene : MonoBehaviour
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



    public void Abrir()
    {
            SceneManager.LoadScene(novaCena);
            ScriptKI.SavePosition();
            Slots.Instance.DestruirItem();
    }
}
