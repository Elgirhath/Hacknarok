using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable {
    private Transform player;
    public enum Axis {
        X,
        Y
    };

    public float minCloseDist;
    public Axis normalAxis;

    private bool _isClosed = true;
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
        if (isClosed) {
            player = controller.transform;
            isClosed = false;
        }
    }

    private void Update() {
        if (!isClosed) {
            float distance = Vector2.Distance(player.position, transform.position);
            if (distance > minCloseDist) {
                Debug.Log(distance);
                isClosed = true;
            }
        }
    }

    private Vector2 normal {
        get {
            switch (normalAxis) {
                case Axis.X:
                    return Vector2.right;
                case Axis.Y:
                    return Vector2.up;
                default:
                    throw new Exception("Wrong axis");
            }
        }
    }
}
