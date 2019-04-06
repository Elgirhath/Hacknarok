using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildReturn : MonoBehaviour, Interactable
{
	public void Interact(InteractController controller) {
		ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();
		if (childHandler.isEquipped) {
			Debug.Log("Kid has been napped");
			childHandler.Destroy();
		}
	}
}