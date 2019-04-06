using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable {
    public enum Axis {
        X,
        Y
    };

    public Axis wingAxis;
    
    private bool _isClosed;
    private bool isClosed {
        get { return _isClosed; }
        set {
            _isClosed = value;
            foreach (Transform child in transform) {
                child.gameObject.SetActive(value);
            }
        }
    }
    
    public void Interact(InteractController controller) {
        isClosed = false;
    }

    private void Update() {
        if (isClosed) {
            
        }
    }

    private Vector2 GetWingVector() {
        switch (wingAxis) {
            case Axis.X:
                return Vector2.up;
            case Axis.Y:
                return Vector2.right;
            default:
                throw new Exception("Wrong axis");
        }
    }
}
