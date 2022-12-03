using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario 
{
    private List<Item> itemList;
    public Inventario()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.QuartoSecreto, amount = 1 });
        Debug.Log(itemList.Count);
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
