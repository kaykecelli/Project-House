using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    { 
        QuartoSecreto,
        elefante,
        isqueiro,
        chaveBanheiro

    
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.QuartoSecreto:     return ItemAssets.Instance.ChaveSprite;
            case ItemType.elefante:          return ItemAssets.Instance.ChaveSprite;
            case ItemType.isqueiro:          return ItemAssets.Instance.ChaveSprite;
            case ItemType.chaveBanheiro:     return ItemAssets.Instance.ChaveSprite;
        }
    }
}
