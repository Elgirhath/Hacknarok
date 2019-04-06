using UnityEngine;

public class InteractController : MonoBehaviour {
	public Vector3 tooltipRelativePosition;
	public float maxDistance;

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

		if (interactable && Input.GetButtonDown("Interact")) {
			interactable.GetComponent<Interactable>().Interact();
		}
	}

	private Transform FindInteractable() {
		GameObject[] items = GameObject.FindGameObjectsWithTag("Interactable");
		float minDist = 0f;
		Transform closest = null;
		foreach (var obj in items) {
			if (!closest || Vector2.Distance(obj.transform.position, transform.position) < minDist) {
				closest = obj.transform;
				minDist = Vector2.Distance(obj.transform.position, transform.position);
			}
		}
		
		return minDist < maxDistance ? closest : null;
	}
	
	public void Interact() {
		interactable.GetComponent<Interactable>().Interact();
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
