using UnityEngine;
using UnityEngine.UI;

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
		newInteractable = IsAvailable(newInteractable) ? newInteractable : null;

		interactable = newInteractable;

		if (interactable && Input.GetButtonDown(interactButton)) {
			Interact();
		}
	}

	private bool IsAvailable(Transform item) {
		if (!item)
			return false;
		SpriteGroup group = item.GetComponentInParent<SpriteGroup>();
		Vector2 itemPos = group?.transform?.position ?? item.position;
		Vector2 pos = transform.position;
		Vector2 direction = itemPos - pos;
		RaycastHit2D[] hits = Physics2D.RaycastAll(pos, direction, direction.magnitude);
		foreach (var hit in hits) {
			if (hit.transform == item)
				continue;
			if (hit.transform.parent == item) 
				continue;
			if (hit.transform.GetComponentInParent<SpriteGroup>() == group) 
				continue;
			if (hit.transform.CompareTag("Window"))
				continue;
			if (hit.transform.CompareTag("Player1"))
				continue;
			if (hit.transform.CompareTag("Player2"))
				continue;
			return false;
		}

		return true;
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
		Vector3 screenPos = Camera.main.WorldToScreenPoint(tooltipPosition);
		Transform ui = GameObject.FindGameObjectWithTag("UI").transform;
		tooltip = Instantiate(tooltipPrefab, screenPos, Quaternion.identity, ui);
		tooltip.GetComponentInChildren<Text>().text = interactButton == "Interact" ? "/" : "E";
	}

	public void Deselect() {
		Destroy(tooltip);
		tooltip = null;
	}
}
