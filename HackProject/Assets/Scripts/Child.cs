using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour, Interactable
{
    private PlayerController playerController;
    private SpriteRenderer sprite;

    public Sprite childSide;
    public Sprite childFront;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerController = null;
    }

    void Update()
    {
        if (playerController)
        {
            if (playerController.currentDirection.x != 0)
            {
                sprite.sprite = childFront;
                sprite.flipX = !(playerController.currentDirection.x > 0);
            }
            else if (playerController.currentDirection.y != 0)
            {
                sprite.sprite = childSide;
            }
        }

        //Debug.Log("X: "+playerDirection.x+" || Y: "+ playerDirection.y);
    }
    
    public void Interact(InteractController controller) {
        ChildHandler childHandler = controller.GetComponentInChildren<ChildHandler>();

        ChildHandler currentHandler = GetComponentInParent<ChildHandler>();
        playerController = controller.GetComponent<PlayerController>();
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