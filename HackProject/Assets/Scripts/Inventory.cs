using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList = new List<Item>();

    public void Add(Item item)
    {
        itemList.Add(item);
    }

    public void Remove(Item item)
    {
        foreach (Item i in itemList)
        {
            if (i == item)
            {
                itemList.Remove(i);
                return;
            }
        }
    }

    public bool Contains(Item item) {
        foreach (var listItem in itemList) {
            if (listItem == item) {
                return true;
            }
        }

        return false;
    }
}
