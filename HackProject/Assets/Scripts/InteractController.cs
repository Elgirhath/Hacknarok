using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour {

    public string button;

    public Vector3 tooltipRelativePosition;
    public GameObject tooltipPrefab;
    private GameObject tooltip;

    public Interactable interactable;

    private bool isSelected = false;

    public void Interact() {
        interactable.Interact();
    }

    public void Select() {
        Vector3 tooltipPosition = transform.position + tooltipRelativePosition;
        tooltip = Instantiate(tooltipPrefab, tooltipPosition, Quaternion.identity);
        isSelected = true;
    }

    private void Update() {
        if (!isSelected && isInRange) {
            Select();
        }
    }

    private bool isInRange {
        get { return true; }
    }

}