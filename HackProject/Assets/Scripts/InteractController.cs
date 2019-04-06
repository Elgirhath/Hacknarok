﻿using UnityEngine;

public class InteractController : MonoBehaviour {
	public Vector3 tooltipRelativePosition;
	public float maxDistance;
	public string interactButton;

	private Transform _interactable;
	private Transform interactable {
		get { return _interactable; }

		set {
			if (!value) {
				_interactable = value;
				Deselect();
			}
			else if (!interactable) {
				_interactable = value;
				Select();
			}
			else {
				Deselect();
				_interactable = value;
				Select();
			}
		}
	}
	public GameObject tooltipPrefab;
	private GameObject tooltip;

	private void Update() {
		Transform newInteractable = FindInteractable();
		interactable = newInteractable;

		if (interactable && Input.GetButtonDown(interactButton)) {
			Interact();
		}
	}

	private Transform FindInteractable() {
		GameObject[] items = GameObject.FindGameObjectsWithTag("Interactable");
		float minDist = 0f;
		Transform closest = null;
		Transform child = transform.GetComponentInChildren<Child>()?.transform;
		foreach (GameObject obj in items) {
			if (obj == child?.gameObject)
				continue;
			bool isClosest = Vector2.Distance(obj.transform.position, transform.position) < minDist;
			if (!closest || isClosest) {
				closest = obj.transform;
				minDist = Vector2.Distance(obj.transform.position, transform.position);
			}
		}

		Transform target = minDist < maxDistance ? closest : child;
		return target;
	}
	
	public void Interact() {
		interactable.GetComponent<Interactable>().Interact(this);
	}
	
	public void Select() {
		Vector3 tooltipPosition = interactable.position + tooltipRelativePosition;
		tooltip = Instantiate(tooltipPrefab, tooltipPosition, Quaternion.identity);
	}

	public void Deselect() {
		Destroy(tooltip);
		tooltip = null;
	}
}
