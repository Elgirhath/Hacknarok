using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildHandler : MonoBehaviour
{
    public void Equip(Child child) {
        child.transform.parent = transform;
        child.transform.localPosition = -Vector3.forward;
    }
}
