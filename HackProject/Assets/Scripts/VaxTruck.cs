using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaxTruck : MonoBehaviour, Interactable {
	public Item vaxItem;
	public void Interact(InteractController controller) {
		Inventory inventory = controller.GetComponent<Inventory>();
		inventory.Add(vaxItem);
	}
}
