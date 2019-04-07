using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildHandler : MonoBehaviour {
    public bool isEquipped = false;
    public Child _child;
    public void Equip(Child child) {
        _child = child;
        _child.transform.parent = transform;
        _child.transform.localPosition = -Vector3.forward;
        isEquipped = true;
    }

    public void Remove() {
        _child.transform.parent = null;
        _child = null;
        isEquipped = false;
    }

    public void Destroy() {
        Debug.Log("Destroyin!");
        Destroy(_child.gameObject);
        Remove();
    }
}