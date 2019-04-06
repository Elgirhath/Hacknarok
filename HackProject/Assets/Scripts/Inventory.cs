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
            if (i.GetType() == item.GetType())
            {
                itemList.Remove(i);
                return;
            }
        }
    }
}
