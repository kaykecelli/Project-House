using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public static Slots Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void DestruirItem()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child);
        }
    }
}
