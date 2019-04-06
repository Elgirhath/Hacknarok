using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour, Interactable
{
    public void Interact(InteractController controller) {
        Debug.Log("Interacted");
    }
}
