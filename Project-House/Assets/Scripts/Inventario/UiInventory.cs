using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    Inventario inventario;
    Transform ItemSlotContainer;
    Transform ItemSlotTemplate;

    private void Start()
    {
        ItemSlotContainer = transform.Find("ItemSlotContainer");
        ItemSlotTemplate = ItemSlotContainer.Find("ItemSlotTemplate");
    }
    public void SetInventory(Inventario inventario)
    {
        this.inventario = inventario;
        RefreshInventoryItens();
    }
    void RefreshInventoryItens()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach(Item item in inventario.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(ItemSlotTemplate, ItemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
           
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            y++;
                if(y > 4)
            {
                y = 0;
                x++;
            }
        }
    }
}
