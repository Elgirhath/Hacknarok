using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour, Interactable
{
    public void Interact(InteractController controller) {
        ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();

        ChildHandler currentHandler = GetComponentInParent<ChildHandler>();
        if (currentHandler && currentHandler.isEquipped && currentHandler != childHandler) {
            currentHandler.Remove();
        }
        
        if (childHandler.isEquipped) {
            childHandler.Remove();
            return;
        }

        childHandler.Equip(this);
    }
}