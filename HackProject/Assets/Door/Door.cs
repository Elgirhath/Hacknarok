using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable {
    private Transform player;

    public bool isLocked;
    public float minCloseDist;
    public Item key;

    private bool _isClosed = true;
    private bool isClosed {
        get { return _isClosed; }
        set {
            _isClosed = value;
            GetComponent<Collider2D>().enabled = value;
            foreach (Transform child in transform) {
                child.gameObject.SetActive(value);
            }
        }
    }
    
    public void Interact(InteractController controller) {
        if (isClosed) {
            player = controller.transform;
            
            if (isLocked) {
                Inventory inventory = player.GetComponent<Inventory>();
                if (!inventory.Contains(key)) {
                    Debug.Log("No key");
                    return;
                }
                
                inventory.Remove(key);
                isLocked = false;
            }
            isClosed = false;
        }
    }

    private void Update() {
        if (!isClosed) {
            float distance = Vector2.Distance(player.position, transform.position);
            if (distance > minCloseDist) {
                isClosed = true;
            }
        }
    }
}
