using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCene : MonoBehaviour
{
    [SerializeField]
    string novaCena;

    

    public void Abrir()
    {
        
        
            SceneManager.LoadScene(novaCena);
        
    }
}
