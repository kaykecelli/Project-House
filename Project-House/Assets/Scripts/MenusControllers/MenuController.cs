using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string newGame;

    public void PlayGame()
    {
        SceneManager.LoadScene(newGame);
    }
    public void Sair()
    {
        Application.Quit();

    }
}
