using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour, Interactable {
	public Item item;
	public void Interact(InteractController controller) {
		Inventory inventory = controller.GetComponent<Inventory>();
		inventory.Add(item);
	}
}
