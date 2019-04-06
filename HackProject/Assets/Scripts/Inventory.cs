using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;

    private void Add(Item item)
    {
        itemList.Add(item);
    }

    private void Remove(Item item)
    {
        foreach (Item i in itemList)
        {
            if (i.GetType() == item.GetType())
            {
                itemList.Remove(i);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
