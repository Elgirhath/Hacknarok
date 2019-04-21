using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList = new List<Item>();
    private Transform inventoryUI;
    public Transform uiItemPrefab;

    private void Start()
    {
        GameObject playerUI = null;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (go.Equals(gameObject))
                continue;
            playerUI = go;
        }

        if (playerUI)
        {
            foreach (Transform child in playerUI.transform)
            {
                if (child.tag.Equals("Inventory"))
                {
                    inventoryUI = child;
                }
            }
        }
    }

    public void Add(Item item)
    {
        itemList.Add(item);
        Instantiate(uiItemPrefab, inventoryUI).GetComponent<Image>().sprite = item.sprite;
        Debug.Log(inventoryUI);
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
