using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildReturn : MonoBehaviour, Interactable
{
	public void Interact(InteractController controller) {
		ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();
		if (childHandler.isEquipped) {
			Task task = TaskManager.instance.TaskExists(GameManager.TaskType.BABYSTEAL);
			if (task) {
				Debug.Log("Kid has been napped");
				childHandler.Destroy();
				task.Accomplish();
			}
		}
	}
}