using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildReturn : MonoBehaviour, Interactable
{
	private GameObject feedbackContainer;
	public GameObject feedbackTextPrefab;
	private GameObject feedbackText;
	public void Interact(InteractController controller) {
		ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();
		if (childHandler.isEquipped) {
			Task task = TaskManager.instance.TaskExists(GameManager.TaskType.BABYSTEAL);
			if (task) {
				feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
				feedbackText.GetComponent<Text>().text = "Kid has been napped";
				Destroy(feedbackText, 5.0f);
				childHandler.Destroy();
				task.Accomplish();
			}
			else
			{
				feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
				feedbackText.GetComponent<Text>().text = "Not now man! Now is not the time for that!";
				Destroy(feedbackText, 5.0f);
			}
		}
	}

	void Start()
	{
		feedbackContainer = GameObject.FindGameObjectWithTag("Feedback");
	}
}