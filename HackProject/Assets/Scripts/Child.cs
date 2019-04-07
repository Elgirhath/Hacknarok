using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour, Interactable
{
    public void Interact(InteractController controller) {
        ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();
        if (childHandler.isEquipped) {
            childHandler.Remove();
            return;
        }

        childHandler.Equip(this);
    }
}