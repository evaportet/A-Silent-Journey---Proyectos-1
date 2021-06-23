using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType { key, enemy, button}

public class Door : Interactable
{
    public KeyDoorState myKDState;
    public DoorType thisDoorType;
    public bool isOpen;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public Transform target;

    public void OnEnable()
    {
        isOpen = myKDState.RuntimeValue;
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if (playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    Open();
                    if (target.position.x > 1.4)
                    {
                        contextOff.Raise();
                    }
                    
                }
            }
        }
        else if ((myKDState.RuntimeValue) == true)
        {

            Open();

            if(target.position.x > 1.4) { 
                    
                contextOff.Raise();
            }
        }
        myKDState.RuntimeValue = isOpen;
    }
    public void Open()
    {
        physicsCollider.enabled = false;
        doorSprite.enabled = false;
        isOpen = true;
        

    }
    public void Close()
    {

    }
}
