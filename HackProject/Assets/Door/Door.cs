using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, Interactable {
    private Transform player;

    public bool isLocked;
    public float minCloseDist;
    public Item key;
    private GameObject feedbackContainer;
    public GameObject feedbackTextPrefab;
    private GameObject feedbackText;

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
                    feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
                    feedbackText.GetComponent<Text>().text = "You need a key to open that door!";
                    Destroy(feedbackText, 5.0f);
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

    void Start()
    {
        feedbackContainer = GameObject.FindGameObjectWithTag("Feedback");
    }
}
