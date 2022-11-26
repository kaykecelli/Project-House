using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SavePositionPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject ObjetoPlayer;
    Transform transformP;
    private Vector3 posSave;
    private bool PosSaved;


    private void Start()
    {
        PosSaved = false;
        transformP = ObjetoPlayer.GetComponent<Transform>();
       
    }


    public void SavePosition()
    {
        //Debug.Log("SavePosition is being called");
        posSave = transformP.transform.position;
        PosSaved = true;
    }

    public void PlacePlayer()
    {
       // Debug.Log("Place Player is being called");
        if (PosSaved == true)
        {
            //Debug.Log("Place Player is saved");
            transformP.transform.position = posSave;
            PosSaved = false;
        }
        else
        {
           // Debug.Log("There is no saved position");
        }
    }
}
