using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{
    // Start is called before the first frame update
    public void OnDisable()
    {
        PlayerPrefs.SetInt("open", BoolToInt(isOpen));
    }
    public void OnEnable()
    {
        isOpen = false;
    }
    private void Start()
    {
        isOpen = IntToBool(PlayerPrefs.GetInt("open"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && playerInRange)
        {
            
            if (!isOpen)
            {
                if (dialogBox.activeInHierarchy)
                {
                    //if(Target.position.x == -13.37F)
                    dialogBox.SetActive(false);
                }
                else
                {
                    // Dialog window on
                    dialogBox.SetActive(true);
                }
                OpenChest();
                
            }
            else
            {
                dialogBox.SetActive(false);
                ChestAlreadyOpen();
            }
            

        }
        else if (!playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                //if(Target.position.x == -13.37F)
                dialogBox.SetActive(false);
            }
        }
    }
    public void OpenChest()
    {
        // set chest to open       
        anim.SetBool("opened", true);
        isOpen = true;
        // dialog text = contents text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the signal to the player to animate
        raiseItem.Raise();        
        // raise the context clue
        contextOn.Raise();
        
        
    }

    public void ChestAlreadyOpen()
    {
        //raise the signal to the player to stop animating
        raiseItem.Raise();
        //Dialog off
        dialogBox.SetActive(false);
           
            
            
        
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")  && !isOpen)
        {
            playerInRange = true;
            contextOn.Raise();

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")  && isOpen)
        {
            playerInRange = false;
            //dialogBox1.SetActive(false);

            //dialogText.text = dialog;                    
            contextOff.Raise();

            //dialogBox.SetActive(false);
        }
    }
}
