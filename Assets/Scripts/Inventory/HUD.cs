using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    private void OnEnable()
    {
        inventory.ItemAdded += Inventory_ItemAdded;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory Panel");
        int index = -1;

        foreach (Transform slot in inventoryPanel)
        {
            index++;

            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                int itemCount = e.Item.Slot.Count;

                if (itemCount > 1)
                {
                    txtCount.text = itemCount.ToString();
                }
                else
                {
                    txtCount.text = "";
                }

                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory Panel");
        int index = -1;

        foreach (Transform slot in inventoryPanel)
        {
            index++;

            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if (itemDragHandler.Item == null)
                continue;

            if(e.Item.Slot.Id == index)
            {
                int itemCount = e.Item.Slot.Count;

                itemDragHandler.Item = e.Item.Slot.FirstItem;

                if (itemCount < 2)
                {
                    txtCount.text = "";
                }
                else
                {
                    txtCount.text = itemCount.ToString();
                }

                if (itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }

                break;
            }
        }
    }

    private void OnDisable()
    {
        inventory.ItemAdded -= Inventory_ItemAdded;
        inventory.ItemRemoved -= Inventory_ItemRemoved;
    }
}
